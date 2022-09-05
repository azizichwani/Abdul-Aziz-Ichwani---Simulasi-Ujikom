using MatchPicture.TileObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.TileGroup
{
    public class TileGroupController : MonoBehaviour
    {
        [SerializeField] private TileController _tileObject;
        [SerializeField] private Transform _tileSpawnPos;
        [SerializeField] private Vector2 _startPosition = new Vector2(-2.15f, 3.62f);
        [SerializeField] private Vector2 _offset = new Vector2(1.5f, 1.52f);

        [HideInInspector]
        public List<TileController> _tileObjects;

        public TileController tileObject => _tileObject;
        public Transform tileSpawnPos => _tileSpawnPos;
        public Vector2 startPosition => _startPosition;
        public Vector2 offset => _offset;

        private List<Sprite> _spriteList = new List<Sprite>();
        private List<string> _spritePathList = new List<string>();
        private Sprite _firstSprite;
        private string _firstSpritePath;


        // Start is called before the first frame update
        void Start()
        {
            LoadSprites();
            SpawnTileGroup(4, 5, startPosition, offset, false);
            MoveTile(4, 5, startPosition, offset);
        }

        private void LoadSprites()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SpawnTileGroup(int rows, int columns, Vector2 Pos, Vector2 offset, bool scaleDown)
        {
            for(int col = 0; col < columns; col++)
            {
                for(int row = 0; row < rows; row++)
                {
                    var tempTileObject = (TileController)Instantiate(tileObject, tileSpawnPos.position, tileSpawnPos.transform.rotation);

                    tempTileObject.name = tempTileObject.name + 'c' + col + 'r' + row;
                    _tileObjects.Add(tempTileObject);
                }
            }
        }

        private void MoveTile(int rows, int columns, Vector2 pos, Vector2 offset)
        {
            var index = 0;
            for(var col =0; col < columns; col++)
            {
                for(int row = 0; row<rows; row++)
                {
                    var targetPosition = new Vector3((pos.x + (offset.x * row)), (pos.y - (offset.y * col)), 0.0f);
                    StartCoroutine(MoveToPosition(targetPosition, _tileObjects[index]));
                    index++;
                }
            }
        }

        private IEnumerator MoveToPosition(Vector3 target, TileController obj)
        {
            var randomDis = 7;
            while(obj.transform.position != target)
            {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, randomDis * Time.deltaTime);
                yield return 0;
            }
        }
    }

}
