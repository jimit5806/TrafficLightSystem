using System;
using System.Web.UI;

namespace TrafficLightSystem
{
    public partial class TrafficLightSystem : System.Web.UI.Page
    {

        /// <summary>
        /// During page load, timer controls will be disable and these timer controls will be enabled on Start button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TimerDisplay.Enabled = false;
                TimerCounter.Enabled = false;
                lblCounter.Text = "Counter will be start on click of Start button";
                lblStatus.Text = "Status will be display after click on Start button";
            }

        }

        /// <summary>
        /// This timer control event will be trigger as per dynamic interval set by iterateCounter method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TimerDisplay_Tick(object sender, EventArgs e)
        {
            trafficLightSystem(TrafficLights.varCounter, TrafficLights.blPeaktime);
        }

        /// <summary>
        /// This timer control event will be trigger at every 1 second which is defined in aspx design page and this timer will run counter at each 1 second.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TimerCounter_Tick(object sender, EventArgs e)
        {

            if (TrafficLights.varTimer != 0)
            {
                TrafficLights.varTimer = TrafficLights.varTimer == 1 ? TrafficLights.varTimer : TrafficLights.varTimer - 1;
                lblCounter.Text = TrafficLights.varTimer.ToString();
            }
            else
                lblError.Text = "Please select date and time.";
        }

        /// <summary>
        /// This method will be called from timerdisplay tick event as per dynamic interval which will pass counter and peaktime as a paramter.
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="peaktime"></param>
        private void trafficLightSystem(int counter, bool peaktime)
        {
            switch (counter)
            {
                case 1:
                    iterateCounter(colors.Green, peaktime, directions.northsouth);
                    break;

                case 2:
                    iterateCounter(colors.Yellow, peaktime, directions.northsouth);
                    break;

                case 3:
                    iterateCounter(colors.Red, peaktime, directions.northsouth);
                    break;

                case 4:
                    iterateCounter(colors.Green, peaktime, directions.eastwest);
                    break;

                case 5:
                    iterateCounter(colors.Yellow, peaktime, directions.eastwest);
                    break;

                case 6:
                    iterateCounter(colors.Red, peaktime, directions.eastwest);
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// This method will be called from timerdisplay tick event as per dynamic interval which will pass counter, peaktime and greenarrow as a paramter.
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="peaktime"></param>
        /// <param name="greenArrow"></param>
        private void iterateCounter(colors paramColor, bool peakTime, directions paramDirection)
        {

            NorthGreen.Visible = false;
            NorthRed.Visible = false;
            SouthGreen.Visible = false;
            SouthRed.Visible = false;
            EastGreen.Visible = false;
            EastRed.Visible = false;
            WestGreen.Visible = false;
            WestRed.Visible = false;
            NorthYellow.Visible = false;
            SouthYellow.Visible = false;
            EastYellow.Visible = false;
            WestYellow.Visible = false;

            switch (paramColor)
            {
                case colors.Green:

                    if (paramDirection == directions.northsouth)
                    {
                        if (peakTime)
                        {
                            TimerDisplay.Interval = 40000;
                            TrafficLights.varTimer = 40;
                        }
                        else
                        {
                            TimerDisplay.Interval = 20000;
                            TrafficLights.varTimer = 20;
                        }

                        TrafficLights.varCounter = 2;

                        NorthGreen.Visible = true;
                        SouthGreen.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }
                    else
                    {

                        if (peakTime)
                        {
                            TimerDisplay.Interval = 10000;
                            TrafficLights.varTimer = 10;
                        }
                        else
                        {
                            TimerDisplay.Interval = 20000;
                            TrafficLights.varTimer = 20;
                        }

                        TrafficLights.varCounter = 5;

                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastGreen.Visible = true;
                        WestGreen.Visible = true;
                    }

                    lblStatus.Text = "Have a safe journey";
                    lblCounter.Text = TrafficLights.varTimer.ToString();

                    break;

                case colors.Yellow:

                    if (paramDirection == directions.northsouth)
                    {
                        TrafficLights.varCounter = 3;
                        TrafficLights.varTimer = 5;

                        NorthYellow.Visible = true;
                        SouthYellow.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }
                    else
                    {
                        TrafficLights.varCounter = 6;
                        TrafficLights.varTimer = 5;

                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastYellow.Visible = true;
                        WestYellow.Visible = true;
                    }

                    lblStatus.Text = "slow down your vehicle";
                    TimerDisplay.Interval = 5000;
                    lblCounter.Text = TrafficLights.varTimer.ToString();

                    break;

                case colors.Red:

                    if (paramDirection == directions.northsouth)
                    {
                        TrafficLights.varCounter = 4;
                    }
                    else
                    {
                        TrafficLights.varCounter = 1;
                    }

                    lblStatus.Text = "stop your vehicle";
                    TimerDisplay.Interval = 4000;
                    TrafficLights.varTimer = 4;
                    lblCounter.Text = TrafficLights.varTimer.ToString();

                    NorthRed.Visible = true;
                    SouthRed.Visible = true;
                    EastRed.Visible = true;
                    WestRed.Visible = true;

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// On click of Start button, this event will trigger which will validate Date is selected or not and check/set peak time and call first south bound Green counter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form[txtdate.UniqueID]))
            {

                lblError.Text = string.Empty;

                DateTime dtTrafficTime = DateTime.Parse(Request.Form[txtdate.UniqueID]);
                bool peaktimeMorning = false;
                bool peaktimeEvening = false;

                TimeSpan startMorning = new TimeSpan(8, 0, 0);
                TimeSpan endMorning = new TimeSpan(10, 0, 0);
                TimeSpan startEvening = new TimeSpan(17, 0, 0);
                TimeSpan endEvening = new TimeSpan(19, 0, 0);
                TimeSpan trafficTime = dtTrafficTime.TimeOfDay;

                // see if start comes before end for morning peak time
                if (startMorning < endMorning)
                    peaktimeMorning = startMorning <= trafficTime && trafficTime <= endMorning;
                // start is after end, so do the inverse comparison
                else
                    peaktimeMorning = !(endMorning <= trafficTime && trafficTime <= startMorning);

                // see if start comes before end for evening peak time
                if (startEvening < endEvening)
                    peaktimeEvening = startEvening <= trafficTime && trafficTime <= endEvening;
                // start is after end, so do the inverse comparison
                else
                    peaktimeEvening = !(endEvening <= trafficTime && trafficTime <= startEvening);

                TrafficLights.blPeaktime = peaktimeMorning == true || peaktimeEvening == true ? true : false;

                TimerDisplay.Enabled = true;
                TimerCounter.Enabled = true;

                lblCounter.Text = TrafficLights.varTimer.ToString();

                NorthNoLight.Visible = false;
                SouthNoLight.Visible = false;
                EastNoLight.Visible = false;
                WestNoLight.Visible = false;

                iterateCounter(colors.Green, TrafficLights.blPeaktime, directions.northsouth);

            }
            else
                lblError.Text = "Please select date and time.";
        }

        /// <summary>
        /// This event will be triggered on Reset button click which will refresh whole page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// Below enum is used to check/set traffic lights with arrow. 
        /// </summary>
        enum colors
        {
            Green,
            Yellow,
            Red
        }

        /// <summary>
        /// Below enum is used to check/set traffic lights directions.
        /// </summary>
        enum directions
        {
            northsouth,
            eastwest
        }
    }

    public static class TrafficLights
    {
        /// <summary>
        /// This static variable is used to run counter and show counter value in label lblCounter.
        /// </summary>
        public static int varCounter = 1;

        /// <summary>
        /// This variable is used to check/set counter.
        /// </summary>
        public static int varTimer = 20;

        /// <summary>
        /// This static variable is used to check/set selected time is pick time or not.
        /// </summary>
        public static bool blPeaktime = false;
    }
}