using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeItemDetector : MonoBehaviour
{

    private ColorChangeItem colorChangeItem;
    public event EventHandler<OnColorChangeItemFoundEventArgs> OnColorChangeItemFound;

    private float stepDistance = 10f;

    private Vector3 startingPosition;
    public class OnColorChangeItemFoundEventArgs : EventArgs
    {
        public ColorChangeItem colorChangeItem;
    }

    private void Awake()
    {
        colorChangeItem = null;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        SearchForColorChangeItem();
    }
    private void SearchForColorChangeItem()
    {
        if (colorChangeItem == null)
        {
            transform.position = new Vector3(0, transform.position.y - (stepDistance * Time.deltaTime), transform.position.z);
        }

        else
        {

            if (colorChangeItem.GetColor() == Color.black)
            {
                TryAgain();
            }
            else
            {
                OnColorChangeItemFound?.Invoke(this, new OnColorChangeItemFoundEventArgs
                {
                    colorChangeItem = this.colorChangeItem
                });
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ColorChangeItem colorChangeItem))
        {
            this.colorChangeItem = colorChangeItem;
        }
    }

    public ColorChangeItem GetColorChangeItem()
    {
        return colorChangeItem;
    }

    public void SetStepDistance(float val)
    {
        stepDistance = val;
    }

    public void SetStartingPosition(Vector3 pos)
    {
        startingPosition = pos;
    }
    private void TryAgain()
    {
        colorChangeItem = null;
        transform.position = startingPosition;
    }
}
