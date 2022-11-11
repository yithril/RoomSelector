//set initial room state
var roomSelectedArray = new bool[16]
{
    true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false
};

//make a 2d array of each room and their neighbors
var roomArray = new int[16][];

//my sort of adjacency matrix
//normally you have 1 or 0 for if it's the neighbor, but I figured why not just have indexes
roomArray[0] = new int[2] { 1, 4 };
roomArray[1] = new int[3] { 0, 2, 5 };
roomArray[2] = new int[3] { 1, 3, 6 };
roomArray[3] = new int[2] { 2, 7 };
roomArray[4] = new int[3] { 0, 5, 8 };
roomArray[5] = new int[4] { 1, 4, 6, 9 };
roomArray[6] = new int[4] { 2, 5, 7, 10 };
roomArray[7] = new int[3] { 3, 6, 11 };
roomArray[8] = new int[3] { 4, 9, 12 };
roomArray[9] = new int[4] { 5, 8, 10, 13 };
roomArray[10] = new int[4] { 6, 9, 11, 14 };
roomArray[11] = new int[3] { 7, 10, 15 };
roomArray[12] = new int[2] { 8, 13 };
roomArray[13] = new int[3] { 9, 12, 14 };
roomArray[14] = new int[3] { 10, 13, 15 };
roomArray[15] = new int[2] { 11, 14 };


//does simpl+ have resizeable arrays?
var visitedNodes = new List<int>();

bool CanSelectRoom(int roomNumber)
{
    if (roomNumber == 0)
    {
        return true;
    }

    if (roomNumber < 0 || roomNumber > roomArray.Length)
    {
        throw new ArgumentOutOfRangeException();
    }

    visitedNodes.Add(roomNumber);

    for (int i = 0; i < roomArray[roomNumber].Length; i++)
    {
        var testNum = roomArray[roomNumber][i];

        //if the room isn't lit up we don't care about it
        if (roomSelectedArray[roomArray[roomNumber][i]] == false)
        {
            continue;
        }
        else if (visitedNodes.Contains(roomArray[roomNumber][i]))
        {
            //already visited
            continue;
        }
        else
        {
            //recursion
            var stopit = CanSelectRoom(roomArray[roomNumber][i]);

            if (stopit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //all it's neighbors are visited and/or are off
    return false;
}

void DeactivateRooms(int roomNumber)
{
    roomSelectedArray[roomNumber] = false;

    for(int i = 0; i < roomArray[roomNumber].Length - 1; i++)
    {
        var canReachZero = CanSelectRoom(roomArray[roomNumber][i]);

        if (!canReachZero)
        {
            roomSelectedArray[roomArray[roomNumber][i]] = false;
        }
    }
}

roomSelectedArray[4] = true;
roomSelectedArray[5] = true;
roomSelectedArray[6] = true;
roomSelectedArray[8] = true;
roomSelectedArray[9] = true;
roomSelectedArray[13] = true;

//var test1 = CanSelectRoom(1);
//var test2 = CanSelectRoom(2);
//var test3 = CanSelectRoom(3); //false
//var test4 = CanSelectRoom(7);
//var test5 = CanSelectRoom(11); //false
//var test6 = CanSelectRoom(15); //false
//var test7 = CanSelectRoom(14);
//var test8 = CanSelectRoom(12); //false

Console.WriteLine(foundZero);