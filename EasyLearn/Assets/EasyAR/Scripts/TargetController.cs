//================================================================================================================================
//
//  Copyright (c) 2015-2019 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using System;
using UnityEngine;

namespace easyar
{
    public abstract class TargetController : MonoBehaviour
    {
        public ActiveControlStrategy ActiveControl;
        public bool HorizontalFlip;

        private bool firstFound;

        public event Action TargetFound;
        public event Action TargetLost;

        public enum ActiveControlStrategy
        {
            HideWhenNotTracking,
            HideBeforeFirstFound,
            BookControlling,
            None,
        }

        public bool IsTracked { get; private set; }

        protected virtual void Start()
        {
            if (!IsTracked && (ActiveControl == ActiveControlStrategy.HideWhenNotTracking || ActiveControl == ActiveControlStrategy.HideBeforeFirstFound))
            {
                gameObject.SetActive(false);
            }
        }

        internal void OnTracking(bool status)
        {
            
            if (IsTracked != status)
            {
                if (status)
                {
                    if (ActiveControl == ActiveControlStrategy.HideWhenNotTracking || (ActiveControl == ActiveControlStrategy.HideBeforeFirstFound && !firstFound))
                    {
                        gameObject.SetActive(true);
                    }
                    else if (ActiveControl == ActiveControlStrategy.BookControlling && firstFound)
                    {
                        GameObject.Find("Play").GetComponent<SpriteRenderer>().enabled = true;
                        GameObject.Find("Play").GetComponent<BoxCollider>().enabled = true;
                    }
                    
                    firstFound = true;
                    if (TargetFound != null)
                    {
                        TargetFound();
                    }
                }
                else
                {
                    if (ActiveControl == ActiveControlStrategy.HideWhenNotTracking)
                    {
                        gameObject.SetActive(false);
                    }
                    else if (ActiveControl == ActiveControlStrategy.BookControlling)
                    {
                        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Hide1"))
                        {
                            obj.GetComponent<BoxCollider>().enabled = false;
                            obj.GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }
                    if (TargetLost != null)
                    {
                        TargetLost();
                    }
                }
                IsTracked = status;
            }
            if (IsTracked)
            {
                OnTracking();
            }
        }

        protected abstract void OnTracking();
    }
}
