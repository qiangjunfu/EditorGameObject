using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTG
{
    /// <summary>
    /// 单独选中物体
    /// </summary>
    public class GizmoManager1 : MonoBehaviour
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
        /// <summary>
        /// Gizmo对应的游戏物体
        /// </summary>
        private GameObject _targetObject;



        private void Start()
        {
            _objectMoveGizmo = RTGizmosEngine.Get.CreateObjectMoveGizmo();
            _objectRotateionGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();
            _objectScaleGizmo = RTGizmosEngine.Get.CreateObjectScaleGizmo();
            _objectUniversalGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();

            _objectMoveGizmo.Gizmo.SetEnabled(false);
            _objectRotateionGizmo.Gizmo.SetEnabled(false);
            _objectScaleGizmo.Gizmo.SetEnabled(false);
            _objectUniversalGizmo.Gizmo.SetEnabled(false);

            _workGizmoId = GizmoId.move;
            _workGizmo = _objectMoveGizmo;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && RTGizmosEngine .Get.HoveredGizmo == null )
            {
                GameObject pickObject = PickGameObject();

                if (pickObject != _targetObject)
                {
                    OnTargetObjectChanged(pickObject);
                }
            }

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

            if (_targetObject != null) _workGizmo.Gizmo.SetEnabled(true);
        }


        void OnTargetObjectChanged(GameObject newTargetObject)
        {
            _targetObject = newTargetObject;

            if (_targetObject != null)
            {
                _objectMoveGizmo.SetTargetObject(_targetObject);
                _objectRotateionGizmo.SetTargetObject(_targetObject);
                _objectScaleGizmo.SetTargetObject(_targetObject);
                _objectUniversalGizmo.SetTargetObject(_targetObject);

                _workGizmo.Gizmo.SetEnabled(true);
            }
            else
            {
                _objectMoveGizmo.Gizmo.SetEnabled(false);
                _objectRotateionGizmo.Gizmo.SetEnabled(false);
                _objectScaleGizmo.Gizmo.SetEnabled(false);
                _objectUniversalGizmo.Gizmo.SetEnabled(false);
            }
        }
    }
}