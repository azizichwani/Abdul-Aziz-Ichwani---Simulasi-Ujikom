using MatchPicture.InputRaycast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.TileObject
{
    public class TileController : MonoBehaviour, IRaycastable
    {
        private Sprite _firstSprite;
        private Sprite _secondSprite;

        public void SetFirstSprite(Sprite sprite, string spritePath)
        {
            _firstSprite = sprite;
            _firstSprite = Resources.Load(spritePath, typeof(Sprite)) as Sprite;
        }

        public void SetSecondSprite(Sprite sprite, string spritePath)
        {
            _secondSprite = sprite;
            _secondSprite = Resources.Load(spritePath, typeof(Sprite)) as Sprite;
        }

        public void ApplyFirstSprite()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _firstSprite;
        }

        public void ApplySecondSprite()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _secondSprite;
        }

        public void ClickedTiles()
        {
            Debug.Log("Click");
        }
    }
}
