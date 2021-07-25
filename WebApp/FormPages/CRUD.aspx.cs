using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Addtional Namespace
using StarTEDSystem.BLL;
using StarTEDSystem.Entities;
#endregion

namespace WebApp.FormPages
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearAllMessages();

            if (!Page.IsPostBack)
            {
                ListSchoolsForSearch();
                ListSchoolsForEdit();
            }
        }

        protected void ViewProgram_Click(object sender, EventArgs e)
        {
            if(SchoolSearchList.SelectedIndex != 0)
            {
                string schoolCode = SchoolSearchList.SelectedValue;

                ListProgramsForSelect(schoolCode);
            }
            else
            {
                MessageWarning.Text = "Please select a school to start";
            }
        }

        protected void SelectProgram_Click(object sender, EventArgs e)
        {
            if (ProgramSearchList.SelectedIndex != 0)
            {
                string programName = ProgramSearchList.SelectedItem.ToString();

                PopulateProgramForm(programName);
            }
            else
            {
                MessageWarning.Text = "Please select a Program to view.";
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            ClearAllMessages();

            if (Page.IsValid)
            {
                Program newItem = BuildProgramObject();

                ProgramController controller = new ProgramController();

                int newProgramID = -1;

                try
                {
                    newProgramID = controller.Program_Add(newItem);
                }
                catch(Exception ex)
                {
                    MessageWarning.Text = "Error occurs when adding new Program. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
                }

                if (newProgramID > 0)
                {
                    SchoolSearchList.SelectedValue = newItem.SchoolCode;
                    ListProgramsForSelect(newItem.SchoolCode);
                    ProgramSearchList.SelectedValue = newProgramID.ToString();
                    ProgramID.Text = newProgramID.ToString();

                    MessageSuccess.Text = "New Program has been added successfully.";
                }
                else
                {
                    MessageWarning.Text = "New Program insert failed. Please try again or contact tech support at 780-000-000.";
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            ClearAllMessages();

            if (Page.IsValid)
            {
                Program selectedItem = BuildProgramObject();
                selectedItem.ProgramID = int.Parse(ProgramID.Text);

                ProgramController controller = new ProgramController();

                int result = -1;

                try
                {
                    result = controller.Program_Update(selectedItem);
                }
                catch (Exception ex)
                {
                    MessageWarning.Text = "Error occurs when updating Program. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
                }

                if (result == 1)
                {
                    SchoolSearchList.SelectedValue = selectedItem.SchoolCode;
                    ListProgramsForSelect(selectedItem.SchoolCode);
                    ProgramSearchList.SelectedValue = selectedItem.ProgramID.ToString();

                    MessageSuccess.Text = "Program '" + selectedItem.ProgramName + "' has been updated successfully.";
                }
                else if (result == 0)
                {
                    Message.Text = "No program data has been updated.";
                }
                else
                {
                    MessageWarning.Text = result + " Program failed failed. Please try again or contact tech support at 780-000-000.";
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProgramID.Text))
            {
                int programID = int.Parse(ProgramID.Text);

                ProgramController sysmgr = new ProgramController();
                int result = sysmgr.Program_Delete(programID);

                if (result == 1)
                {
                    ListProgramsForSelect(SchoolCode.Text);
                    MessageSuccess.Text = "Program deleted successfully.";
                    ClearControls();
                }
                else
                {
                    MessageWarning.Text = "Error occurs when deleting Program. Please try again or contact tech support at 780-000-000.";
                }
                
            }
            else
            {
                Message.Text = "No program record to delete.";
            }
            
        }

        private void ClearControls()
        {
            SchoolSearchList.SelectedIndex = 0;
            ProgramSearchList.SelectedIndex = 0;
            ProgramID.Text = "";
            ProgramName.Text = "";
            Diploma.Text = "";
            SchoolCode.SelectedIndex = 0;
            DmstcTuition.Text = "";
            IntlTuition.Text = "";
        }

        private void ClearAllMessages()
        {
            Message.Text = "";
            MessageWarning.Text = "";
            MessageSuccess.Text = "";
        }

        private void ListSchoolsForSearch()
        {
            try
            {
                SchoolController sysmgr = new SchoolController();
                List<School> info = sysmgr.ListAllSchools();

                SchoolSearchList.DataSource = info;
                SchoolSearchList.DataTextField = "SchoolName";
                SchoolSearchList.DataValueField = "SchoolCode";
                SchoolSearchList.DataBind();

                SchoolSearchList.Items.Insert(0, "Select a school");
            }
            catch (Exception ex)
            {
                MessageWarning.Text = "Fail to generate School search list. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
            }
        }

        private void ListSchoolsForEdit()
        {
            try
            {
                SchoolController sysmgr = new SchoolController();
                List<School> info = sysmgr.ListAllSchools();

                SchoolCode.DataSource = info;
                SchoolCode.DataTextField = "SchoolName";
                SchoolCode.DataValueField = "SchoolCode";
                SchoolCode.DataBind();

                SchoolCode.Items.Insert(0, "Select a school");
            }
            catch (Exception ex)
            {
                MessageWarning.Text = "Fail to generate School editing list. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
            }
        }


        private void ListProgramsForSelect(string schoolCode)
        {

            try
            {
                ProgramController sysmgr = new ProgramController();
                List<Program> info = sysmgr.Programs_FindBySchool(schoolCode);

                ProgramSearchList.DataSource = info;
                ProgramSearchList.DataTextField = "ProgramName";
                ProgramSearchList.DataValueField = "ProgramID";
                ProgramSearchList.DataBind();

                ProgramSearchList.Items.Insert(0, "Select a program");
            }
            catch (Exception ex)
            {
                MessageWarning.Text = "Fail to generate Program search list. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
            }

        }

        private void PopulateProgramForm(string programName)
        {
            try
            {
                ProgramController sysmgr = new ProgramController();
                List<Program> info = sysmgr.Programs_FindByProgramName(programName);

                if (info.Count == 1)
                {
                    Program item = info.FirstOrDefault();

                    ProgramID.Text = item.ProgramID.ToString();
                    ProgramName.Text = item.ProgramName;
                    Diploma.Text = item.DiplomaName;
                    SchoolCode.SelectedValue = item.SchoolCode;
                    DmstcTuition.Text = string.Format("{0:0,0.00}", item.Tuition);
                    IntlTuition.Text = string.Format("{0:0,0.00}", item.InternationalTuition);

                }
                else
                {
                    MessageWarning.Text = "Error occurs when loading the selected program data.";
                }
            }
            catch (Exception ex)
            {
                MessageWarning.Text = "Fail to populate Program editing form. Please contact tech support at 780-000-0000. Error Detail: " + GetInnerException(ex).Message;
            }

        }

        private Program BuildProgramObject()
        {
            Program item = new Program();

            item.ProgramName = ProgramName.Text;
            item.SchoolCode = SchoolCode.SelectedValue;
            item.DiplomaName = Diploma.Text;
            item.Tuition = decimal.Parse(DmstcTuition.Text);
            item.InternationalTuition = decimal.Parse(IntlTuition.Text);

            return item;
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        
    }
}