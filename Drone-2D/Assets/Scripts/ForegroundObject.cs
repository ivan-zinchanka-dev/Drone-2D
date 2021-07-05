using UnityEngine;

public class ForegroundObject : MonoBehaviour
{
    private const float Addend = 10.0f;                                  // distance between camera position and edge of the screen            
    private static float _blocksX = default;                                         // current positions
    private const float UpperPosY = -0.24f;
    private const float LowerPosY = -2.5f;
    private static bool _isUpper = false;                                  // is the last block was upper (level 2) ?
    private static short _upperBlocksCount = 0;
    private static short _lowerBlocksCount = 0;
    private const short MaxBuldingSize = 7;                               // size in blocks
    private const float DistanceBlocks = 2.54f;

    private static float _birdsX = default;
    private const float DistanceBirds = 5.0f;                             // distance between birds

    private void Start()
    {
        _blocksX = WorldGenerator.XPos + Addend;
        _birdsX = WorldGenerator.XPos + Addend;
        _isUpper = false;
        _upperBlocksCount = 0;
        _lowerBlocksCount = 0;
    }

    public void SetBirdInWorld() {

        byte creating = (byte) Random.Range(0, 2);

        if (creating != 0)
        {
            float y = Random.Range(-2.5f, 3.0f);
            transform.position = new Vector3(_birdsX, y, transform.position.z);
        }     

        _birdsX = (_birdsX < WorldGenerator.XPos + Addend) ? (WorldGenerator.XPos + Addend) : (_birdsX + DistanceBirds);
    }

    public void SetBlockInWorld() {

        float? y = null;
        Location location = Location.EMPTY;

        if (_isUpper)
        {
            _isUpper = false;
            y = LowerPosY;
            _lowerBlocksCount++;
        }
        else
        {
            if (_upperBlocksCount + _lowerBlocksCount >= MaxBuldingSize)
            {
                location = Location.EMPTY;
            }
            else if (_upperBlocksCount == 1)
            {
                location = Location.UPPER;
            }
            else if (_lowerBlocksCount == 1)
            {
                location = Location.LOWER;
            }
            else
            {
                int value = Random.Range(0, 15);           // EMPTY 5-15  UPPER 0 LOWER 1-4

                if (value == 0)
                {
                    location = Location.UPPER;
                }
                else if (value <= 4)
                {
                    location = Location.LOWER;
                }
                else if (value > 4) {

                    location = Location.EMPTY;
                }               
            }

            if (location == Location.EMPTY)
            {
                _isUpper = false;
                _upperBlocksCount = 0;
                _lowerBlocksCount = 0;

            }
            else if (location == Location.UPPER)
            {
                _isUpper = true;
                y = UpperPosY;
                _upperBlocksCount++;
            }
            else if (location == Location.LOWER)
            {
                _isUpper = false;
                y = LowerPosY;
                _lowerBlocksCount++;
            }

        }

        if (y != null) {

            transform.position = new Vector3(_blocksX, (float)y, transform.position.z);
        }
        
        if (!_isUpper) {

            _blocksX += DistanceBlocks;
        }      

    }

    private void Update()
    {
        if (WorldGenerator.Pause) {

            return;
        }

        if (this.tag != "Block" && this.transform.position.x + Addend < WorldGenerator.XPos)
        {
            SetBirdInWorld();
        }
        else if (this.tag == "Block" && this.transform.position.x + Addend < WorldGenerator.XPos) {

            SetBlockInWorld();
        }
    }
}

enum Location {

    EMPTY = 0, UPPER = 1, LOWER = 2
}

