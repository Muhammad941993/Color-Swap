using DG.Tweening;
using UnityEngine;

public enum BallColor { Red,Green,Yellw}
public class FreeBall : MonoBehaviour
{
    [SerializeField] BallColor ballColor;
    bool IsBallMoving = false;
    FixedPoint myfixedPoint;
    PlayerInput playerInput;
    LevelController levelController;
   
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        SetBallProperties();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (IsBallMoving)
            transform.position = playerInput.GetMousePosition();


    }
    void BackToFixedPoint()
    {
        CheckIfBallCanSwap();
        MoveToPosition(myfixedPoint.transform.position);
        IsBallMoving = false;
    }
  
    void SetBallProperties()
    {
        playerInput = GetComponent<PlayerInput>();
        transform.position = myfixedPoint.transform.position;
    }
    private void OnMouseDown()
    {
        IsBallMoving = true;
    }
    private void OnMouseUp()
    {
        BackToFixedPoint();
    }
    public void MoveToPosition(Vector3 _Pos)
    {
        transform.DOMove(new Vector3(_Pos.x, _Pos.y, 0), 0);
        transform.DOShakePosition(1f, 0.2f);
    }

    public void SetFixedPoint(FixedPoint fixedPoint)
    {
        myfixedPoint = fixedPoint;
    }
    public BallColor GetColor() => ballColor;

    void CheckIfBallCanSwap()
    {
        foreach (var item in myfixedPoint.GetConnectors())
        {
            if (Vector2.Distance(transform.position, item.transform.position) < 0.5f)
            {
                item.GetFreeBall().MoveToPosition(myfixedPoint.transform.position);
                SwapComponnets(item);
                break;
            }
        }
    }

    public void SwapComponnets(FixedPoint item)
    {
        var x = this;
        myfixedPoint.UpdatePointAndBall(item.GetFreeBall());
        item.UpdatePointAndBall(x);
            levelController.CheckColorsMatch();

    }

}
