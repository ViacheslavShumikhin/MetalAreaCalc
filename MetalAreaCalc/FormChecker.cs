using System.Windows.Forms;

namespace MetalAreaCalc
{
    public static class FormChecker
    {
        public static bool IsFormOpen<T>() where T : Form
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsMainFormOpen()
        {
            return IsFormOpen<MainForm>();
        }
    }
}
