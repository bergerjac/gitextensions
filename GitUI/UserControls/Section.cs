using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;

namespace GitUI.UserControls
{
    public partial class Section : UserControl
    {
        public SectionInfo Info { get; private set; }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]// should use Reset in code
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        new public string Text
        {
            get
            {
                if (Info == null)
                {
                    Info = new SectionInfo("{Title}");
                }
                return Info.Title;
            }
            set
            {
                Reset(new SectionInfo(value));
            }
        }

        public Section()
        {
            InitializeComponent();
            btnObject.Click += OnClick;// DoubleClick does NOT work
        }

        public Section(SectionInfo info)
            : this()
        {
            Reset(info);
        }

        /// <summary>Resets with the specified <paramref name="info"/>.</summary>
        public void Reset(SectionInfo info)
        {
            Info = info;
            btnObject.Text = info.Title;
            _ChildrenList = null;
        }

        ControlCollection ChildControls { get { return layoutChildren.Controls; } }
        IList<Section> _ChildrenList;
        IList<Section> ChildrenList
        {
            get
            {
                if (_ChildrenList == null)
                {
                    return _ChildrenList = ChildControls.Cast<Section>().ToList();
                }
                return _ChildrenList;
            }
        }
        public IEnumerable<Section> Children { get { return ChildrenList; } }

        void OnClick(object sender, EventArgs e)
        {
            if (Info.OnSelecting != null)
            {
                Info.OnSelecting(Info);
            }
            if (Selected != null)
            {
                Selected(this, EventArgs.Empty);
            }
            if (Info.OnSelected != null)
            {
                Info.OnSelected(Info);
            }
        }

        void Expand()
        {
            if (Info.Children == null) { return; }

            ParallelLoopResult result = Parallel.ForEach(
                  Info.Children,
                  new ParallelOptions { TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext() },
                  AddChild
              );
        }

        /// <summary>Adds a single <paramref name="child"/>.</summary>
        public void AddChild(SectionInfo child)
        {
            ChildControls.Add(new Section(child));
        }

        /// <summary>Efficiently, adds a collection of <paramref name="children"/> by pausing layout.</summary>
        public void AddChildren(IEnumerable<SectionInfo> children)
        {
            AddChildren(children, true);
        }

        /// <summary>Adds a collection of <paramref name="children"/>, optionally pausing layout.</summary>
        public void AddChildren(IEnumerable<SectionInfo> children, bool pause)
        {
            if (pause)
            {
                SuspendLayout();
            }
            foreach (SectionInfo child in children)
            {
                AddChild(child);
            }

            if (pause)
            {
                ResumeLayout();
            }
        }

        /// <summary>Resets the child elements.</summary>
        public void ResetChildren(IEnumerable<SectionInfo> children)
        {
            SuspendLayout();

            var newChildren = children.ToList();

            int i = 0;
            int nOld = ChildrenList.Count;
            int nNew = newChildren.Count;
            for (;
                i < nOld &&
                i < nNew;
                i++)
            {
                ChildrenList[i].Reset(newChildren[i]);
            }

            if (nOld < nNew)
            {// (not enough old slots) -> add more children
                AddChildren(newChildren.Skip(i), false);
            }
            else if (nNew < nOld)
            {// too many old slots -> remove leftovers
                for (; i < nOld; i++)
                {
                    ChildControls.RemoveAt(i);
                }
            }

            ResumeLayout();
        }

        public event EventHandler Selected;

        public override string ToString() { return Text; }
    }

    public class SectionInfo
    {
        public SectionInfo(
            string title,
            IEnumerable<SectionInfo> children = null,
            Action<SectionInfo> onSelecting = null,
            Action<SectionInfo> onSelected = null)
        {
            Title = title;
            OnSelecting = onSelecting;
            OnSelected = onSelected;
            Children = children;
        }

        public string Title { get; private set; }
        public Action<SectionInfo> OnSelecting { get; private set; }
        public Action<SectionInfo> OnSelected { get; private set; }
        public IEnumerable<SectionInfo> Children { get; private set; }

        public override string ToString() { return Title; }
    }
}
