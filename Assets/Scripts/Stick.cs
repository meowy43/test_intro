using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        //public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 100f;

        public Vector3 m_targetAngle;

        public Vector3 impactDirection;
        //public Transform point;
        public event System.Action onCollisionStone;

        //private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private bool m_isDown = false;
        private Rigidbody m_rigidbody;
        private Vector3 m_origAngle;


        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_origAngle = transform.localEulerAngles;
        }

        public void Down()
        {
            m_isDown = true;
        }

        public void Up()
        {
            m_isDown = false;
        }


        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (m_isDown)
            {
                //angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime);
                angle.z = Mathf.MoveTowardsAngle(angle.z, m_origAngle.z + m_targetAngle.z, speed * Time.deltaTime);
                angle.x = Mathf.MoveTowardsAngle(angle.x, m_origAngle.x + m_targetAngle.x, speed * Time.deltaTime);
                angle.y = Mathf.MoveTowardsAngle(angle.y, m_origAngle.y + m_targetAngle.y, speed * Time.deltaTime);
            }
            else
            {
                //angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
                angle.z = Mathf.MoveTowardsAngle(angle.z, m_origAngle.z, speed * Time.deltaTime);
                angle.x = Mathf.MoveTowardsAngle(angle.x, m_origAngle.x, speed * Time.deltaTime);
                angle.y = Mathf.MoveTowardsAngle(angle.y, m_origAngle.y, speed * Time.deltaTime);
            }
            transform.localEulerAngles = angle;
            //m_dir = (point.position - m_lastPointPosition).normalized;
            //m_lastPointPosition = point.position;

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty)
            {
                stone.isDirty = true;
                //var contact = other.contacts[0];
                other.rigidbody.AddForce(impactDirection * power, ForceMode.Impulse);
                // Debug.Log("direction v3 " + m_dir);
                onCollisionStone?.Invoke();
            }
        }
    }
}