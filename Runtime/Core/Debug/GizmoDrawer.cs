using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

namespace JosephLyons.Core.Debug
{
    /// <summary>
    /// Class with info on how to draw spheres
    /// </summary>
    public class SphereDrawInfo
    {
        public Vector3 pos;
        public Color color;
        public float radius;


        public SphereDrawInfo(Vector3 _pos, Color _color, float _radius)
        {
            pos = _pos;
            color = _color;
            radius = _radius;
        }
    }


    /// <summary>
    /// Class with info on how to draw line
    /// </summary>
    public class LineDrawInfo
    {
        public Vector3[] points;
        public Color color;


        public LineDrawInfo(Vector3[] _points, Color _color)
        {
            points = _points;
            color = _color;
        }
    }



    /// <summary>
    /// Allows non-MonoBehavior scripts to draw gizmos
    /// </summary>
    public class GizmoDrawer : MonoBehaviour
    {
        static GizmoDrawer _instance;
        public static GizmoDrawer Instance
        {
            get 
            { 
                if(_instance == null) 
                {
                    GameObject go = new GameObject("GizmoDrawer");
                    _instance = go.AddComponent<GizmoDrawer>();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }


        
        //public Dictionary<dynamic, (Vector3[], Color, float)> spheresToDraw = new Dictionary<dynamic, (Vector3[], Color, float)>();
        //public Dictionary<dynamic, (List<(Vector3, Vector3)>, Color)> linesToDraw = new Dictionary<dynamic, (List<(Vector3, Vector3)>, Color)>();


        // When you get back keep working on this to make it not dumb
        // Scripts add things to draw during update, this script sets these two lists in late update to make sure clear in update doesn't overwrite
        Dictionary<System.Object, SphereDrawInfo> persistentSpheresToDraw = new();
        Dictionary<System.Object, LineDrawInfo> persistentLinesToDraw = new();
        
        List<SphereDrawInfo> spheresToDraw = new();
        List<LineDrawInfo> linesToDraw = new();

        List<SphereDrawInfo> sphereDrawInfoToLoad = new();
        List<LineDrawInfo> lineDrawInfoToLoad = new();


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


        /// <summary>
        /// Will draw debug sphere until next update
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="color"></param>
        /// <param name="radius"></param>
        public void AddDebugSphere(Vector3 worldPos, Color color, float radius)
        {
            sphereDrawInfoToLoad.Add(new SphereDrawInfo(worldPos, color, radius));
        }


        /// <summary>
        /// Add sphere to draw until removed
        /// </summary>
        /// <param name="key">Identifier to easily remove sphere later</param>
        /// <param name="worldPos"></param>
        /// <param name="color"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public bool AddPersistentDebugSphere(System.Object key, Vector3 worldPos, Color color, float radius)
        {
            return persistentSpheresToDraw.TryAdd(key, new SphereDrawInfo(worldPos, color, radius));
        }


        /// <summary>
        /// Remove sphere being drawn
        /// </summary>
        /// <param name="key">Identifier of sphere</param>
        /// <returns></returns>
        public bool RemovePersistentDebugSphere(System.Object key)
        {
            return persistentSpheresToDraw.Remove(key);
        }


        /// <summary>
        /// Will draw debug line until next update
        /// </summary>
        /// <param name="worldPoints"></param>
        /// <param name="color"></param>
        public void AddDebugLine(Vector3[] worldPoints, Color color)
        {
            lineDrawInfoToLoad.Add(new LineDrawInfo(worldPoints, color));
        }


        /// <summary>
        /// Add line to draw until removed
        /// </summary>
        /// <param name="key">Identifier to easily remove line later</param>
        /// <param name="worldPoints"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool AddPersistentDebugLine(System.Object key, Vector3[] worldPoints, Color color)
        {
            return persistentLinesToDraw.TryAdd(key, new LineDrawInfo(worldPoints, color));
        }


        /// <summary>
        /// Remove line being drawn
        /// </summary>
        /// <param name="key">Identifier of line</param>
        /// <returns></returns>
        public bool RemovePersistentDebugLine(System.Object key)
        {
            return persistentLinesToDraw.Remove(key);
        }


        void Update()
        {
            spheresToDraw.Clear();
            linesToDraw.Clear();
        }


        void LateUpdate()
        {
            spheresToDraw = new List<SphereDrawInfo>(sphereDrawInfoToLoad);
            linesToDraw = new List<LineDrawInfo>(lineDrawInfoToLoad);

            sphereDrawInfoToLoad.Clear();
            lineDrawInfoToLoad.Clear();
        }




        void OnDestroy()
        {
            if(_instance == this)
            {
                Instance = null;
            }
        }


        void OnDrawGizmos()
        {
            void DrawSpheres(ICollection<SphereDrawInfo> sphereInfoCollection)
            {
                foreach(SphereDrawInfo sphere in sphereInfoCollection)
                {
                    Gizmos.color = sphere.color;
                    Gizmos.DrawSphere(sphere.pos, sphere.radius);
                }
            }


            void DrawLines(ICollection<LineDrawInfo> lineInfoCollection)
            {
                foreach(LineDrawInfo line in lineInfoCollection)
                {
                    Gizmos.color = line.color;
                    
                    for(int i = 1; i < line.points.Length; i++)
                    {
                        Gizmos.DrawLine(line.points[i - 1], line.points[i]);
                    }
                }
            }


            DrawSpheres(spheresToDraw);
            DrawSpheres(persistentSpheresToDraw.Values);

            DrawLines(linesToDraw);
            DrawLines(persistentLinesToDraw.Values);
        }
    }
}
