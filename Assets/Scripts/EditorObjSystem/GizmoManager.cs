using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RTG
{
    /// <summary>
    /// 全局和局部 没用
    /// </summary>
    public class GizmoManager : MonoBehaviour
    {
        private enum GizmoId
        {
            move = 1,
            Rotate,
            Scale,
            Universal
        }
        /// <summary>
        /// 移动Gizmo
        /// </summary>
        public ObjectTransformGizmo _objectMoveGizmo;
        /// <summary>
        /// 旋转Gizmo
        /// </summary>
        public ObjectTransformGizmo _objectRotateionGizmo;
        /// <summary>
        /// 缩放Gizmo
        /// </summary>
        public ObjectTransformGizmo _objectScaleGizmo;
        /// <summary>
        /// 通用Gizmo
        /// </summary>
        public ObjectTransformGizmo _objectUniversalGizmo;

        /// <summary>
        /// Gizmo对应Id
        /// </summary>
        [SerializeField] private GizmoId _workGizmoId;
        /// <summary>
        /// 当前Gizmo
        /// </summary>
        public ObjectTransformGizmo _workGizmo;

        private List<GameObject> _selectObjects = new List<GameObject>();



        public void Open()
        {
            this.gameObject.SetActive(true);
        }
        public void Close ()
        {
            this.gameObject.SetActive(false );
        }

        private void Start()
        {
            _objectMoveGizmo = RTGizmosEngine.Get.CreateObjectMoveGizmo();
            _objectRotateionGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();
            _objectScaleGizmo = RTGizmosEngine.Get.CreateObjectScaleGizmo();
            _objectUniversalGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();

            _objectMoveGizmo.SetTargetObjects(_selectObjects);
            _objectRotateionGizmo.SetTargetObjects(_selectObjects);
            _objectScaleGizmo.SetTargetObjects(_selectObjects);
            _objectUniversalGizmo.SetTargetObjects(_selectObjects);

            _objectMoveGizmo.Gizmo.SetEnabled(false);
            _objectRotateionGizmo.Gizmo.SetEnabled(false);
            _objectScaleGizmo.Gizmo.SetEnabled(false);
            _objectUniversalGizmo.Gizmo.SetEnabled(false);

            _workGizmoId = GizmoId.move;
            _workGizmo = _objectMoveGizmo;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && RTGizmosEngine.Get.HoveredGizmo == null)
            {
#if UNITY_ANDROID || UNITY_IPHONE
                if (EventSystem .current .IsPointerOverGameObject (Input.GetTouch (0).fingerId ))
#elif UNITY_STANDALONE
                if (EventSystem.current.IsPointerOverGameObject())
#endif
                {
                    Debug.Log($"当前点击在UI上: {EventSystem.current.currentSelectedGameObject}");
                }
                else
                {
                    GameObject pickObject = PickGameObject2();

                    if (pickObject != null)
                    {
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            if (_selectObjects.Contains(pickObject))
                            {
                                _selectObjects.Remove(pickObject);
                                OnSelectionChanged();
                            }
                            else
                            {
                                _selectObjects.Add(pickObject);
                                OnSelectionChanged();
                            }
                        }
                        else
                        {
                            _selectObjects.Clear();
                            _selectObjects.Add(pickObject);
                            OnSelectionChanged();
                        }
                    }
                    else
                    {
                        _selectObjects.Clear();
                        OnSelectionChanged();
                    }
                }
            }


            if (Input.GetKeyDown("g")) SetTransformSpace(GizmoSpace.Global);
            else if (Input.GetKeyDown("l")) SetTransformSpace(GizmoSpace.Local);

            if (Input.GetKeyDown("w")) { SetWorkGizmoId(GizmoId.move); }
            else if (Input.GetKeyDown("e")) { SetWorkGizmoId(GizmoId.Rotate); }
            else if (Input.GetKeyDown("r")) { SetWorkGizmoId(GizmoId.Scale); }
            else if (Input.GetKeyDown("t")) { SetWorkGizmoId(GizmoId.Universal); }
        }


        GameObject PickGameObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            bool isHit = Physics.Raycast(ray, out rayHit, 100);
            if (isHit)
            {
                return rayHit.collider.gameObject;
            }
            return null;
        }
        GameObject PickGameObject2()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            bool isHit = Physics.Raycast(ray, out rayHit, 100);
            Debug.Log(rayHit.collider.gameObject.GetComponent<IClickable>());
            if (isHit && rayHit.collider.gameObject.GetComponent<IClickable>() != null)
            {
                return rayHit.collider.gameObject;
            }
            return null;
        }

        void SetWorkGizmoId(GizmoId gizmoId)
        {
            if (gizmoId == _workGizmoId) return;

            _objectMoveGizmo.Gizmo.SetEnabled(false);
            _objectRotateionGizmo.Gizmo.SetEnabled(false);
            _objectScaleGizmo.Gizmo.SetEnabled(false);
            _objectUniversalGizmo.Gizmo.SetEnabled(false);

            _workGizmoId = gizmoId;
            if (gizmoId == GizmoId.move) _workGizmo = _objectMoveGizmo;
            else if (gizmoId == GizmoId.Rotate) _workGizmo = _objectRotateionGizmo;
            else if (gizmoId == GizmoId.Scale) _workGizmo = _objectScaleGizmo;
            else if (gizmoId == GizmoId.Universal) _workGizmo = _objectUniversalGizmo;

            if (_selectObjects.Count != 0)
            {
                _workGizmo.Gizmo.SetEnabled(true);
                _workGizmo.RefreshPositionAndRotation();
            }
        }


        void OnSelectionChanged()
        {
            if (_selectObjects.Count != 0)
            {
                _workGizmo.Gizmo.SetEnabled(true);
                _workGizmo.SetTargetPivotObject(_selectObjects[_selectObjects.Count - 1]);
                //_workGizmo.RefreshPositionAndRotation();
            }
            else
            {
                _objectMoveGizmo.Gizmo.SetEnabled(false);
                _objectRotateionGizmo.Gizmo.SetEnabled(false);
                _objectScaleGizmo.Gizmo.SetEnabled(false);
                _objectUniversalGizmo.Gizmo.SetEnabled(false);
            }
        }

        void SetTransformSpace(GizmoSpace transformSpace)
        {
            _objectMoveGizmo.SetTransformSpace(transformSpace);
            _objectRotateionGizmo.SetTransformSpace(transformSpace);
            _objectScaleGizmo.SetTransformSpace(transformSpace);
            _objectUniversalGizmo.SetTransformSpace(transformSpace);
        }

    }
}