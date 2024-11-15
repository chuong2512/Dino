﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class AButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }
#endif

        private void Start()
        {
            SetListener(OnClickButton);
            _button.onClick.AddListener(ClickSound);
            OnStart();
        }

        private void ClickSound()
        {
            MasterAudioManager.ClickSound();
            Debug.LogError("Click");
        }

        public void SetListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        protected abstract void OnClickButton();
        protected abstract void OnStart();
    }
}