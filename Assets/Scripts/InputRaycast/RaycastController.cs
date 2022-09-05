using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.InputRaycast
{
    public class RaycastController : MonoBehaviour
    {
        void Update()
        {
            CastOnTap();
        }

        void CastOnTap()
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit)
            {
                GameObject hitObject = hit.transform.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    hitObject.GetComponent<IRaycastable>().ClickedTiles();
                }
            }
        }
    }
}
