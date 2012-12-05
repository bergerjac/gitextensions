using System;
using System.Diagnostics;
using System.Windows.Forms;
using GitCommands;
using ResourceManager.Translation;

namespace GitUI
{
    public sealed partial class FormBranchSmall : GitModuleForm
    {
        readonly string _startPoint;
        private readonly TranslationString _noRevisionSelected =
            new TranslationString("Select 1 revision to create the branch on.");
        private readonly TranslationString _branchNameIsEmpty =
            new TranslationString("Enter branch name.");
        private readonly TranslationString _branchNameIsNotValud =
            new TranslationString("“{0}” is not valid branch name.");

        public FormBranchSmall(GitUICommands aCommands)
            : base(aCommands)
        {
            InitializeComponent();
            Translate();
        }

        /// <summary>Initializes a new instance, where the new branch head will point to the specified start-point.</summary>
        /// <param name="aCommands"></param>
        /// <param name="startPoint">The new branch head will point to this commit. It may be given as a branch name, a commit-id, or a tag. If this option is omitted, the current HEAD will be used instead.</param>
        public FormBranchSmall(GitUICommands aCommands, string startPoint)
            : this(aCommands)
        {
            _startPoint = startPoint;
        }

        public GitRevision Revision { get; set; }

        private void OkClick(object sender, EventArgs e)
        {
            var branchName = BranchNameTextBox.Text.Trim();

            if (branchName.IsNullOrWhiteSpace())
            {
                MessageBox.Show(_branchNameIsEmpty.Text, Text);
                DialogResult = DialogResult.None;
                return;
            }
            if (!Module.CheckBranchFormat(branchName))
            {
                MessageBox.Show(string.Format(_branchNameIsNotValud.Text, branchName), Text);
                DialogResult = DialogResult.None;
                return;
            }
            try
            {
                if (Revision == null && _startPoint == null)
                {
                    MessageBox.Show(this, _noRevisionSelected.Text, Text);
                    return;
                }
                string startPoint = (Revision != null)
                    ? Revision.Guid
                    : _startPoint;
                var branchCmd = GitCommandHelpers.BranchCmd(branchName, startPoint,
                                                                  CheckoutAfterCreate.Checked);
                FormProcess.ShowDialog(this, branchCmd);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}