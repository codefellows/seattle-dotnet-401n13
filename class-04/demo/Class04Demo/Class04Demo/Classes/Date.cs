namespace Class04Demo.Classes
{
    class Date
    {
        private int month = 7; // backing store to set a default value. 

        // logic  can exist in getters and setters/ we have the ability to check/confirm values before the yget set into the object.
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if ((value > 0) && value < 13)
                {
                    month = value;
                }
                else
                {
                    throw new System.Exception("Invalid!");
                }
            }
        }
    }
}
