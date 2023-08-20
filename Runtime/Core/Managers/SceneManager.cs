using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Managers
{
    /// <summary>
    /// Provides functions for performing actions involving scenes
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        static SceneManager _instance;
        public static SceneManager Instance
        {
            get 
            { 
                if(_instance == null) 
                {
                    GameObject go = new GameObject("SceneManager");
                    _instance = go.AddComponent<SceneManager>();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }


        void Awake()
        {
            if(_instance == null) 
            {
                Instance = this;
            }
            else if(_instance != this)
            {
                Destroy(gameObject);
            }
        }


        public void ReloadScene()
        {
            ChangeScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }


        public void ChangeScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }


        public void Quit()
        {
            Application.Quit();
        }


        void OnDestroy()
        {
            if(_instance == this)
            {
                Instance = null;
            }
        }
    }
}
