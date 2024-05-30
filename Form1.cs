namespace MultithreadingT
{
    public partial class Form1 : Form
    {
        private int value = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task task = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            if(movingButton.Location.X + movingButton.Width <= 0)
                            {
                                movingButton.Left = ClientSize.Width;
                            }
                            movingButton.Left -= 1;
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread.Sleep(100 - value);
                }
            });
        }

        private void moveSpeedHScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            value = moveSpeedHScrollBar.Value;
        }
    }
}
