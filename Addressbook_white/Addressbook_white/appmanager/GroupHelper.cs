using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using System.Windows;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.WindowsAPI;




namespace Addressbook_white
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper (ApplicationManager manager) : base(manager) { }
        public string GROUPWINTITLE = "Group Editor";
        

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groupList = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in  root.Nodes)
            {
                groupList.Add(new GroupData
                {
                    Name = item.Text
                });
                
            }
            CloseGroupsDialog(dialog);
            return groupList;

        }

        public void DeleteGroup(GroupData groupToDelete)
        {
            Window dialog = OpenGroupsDialog();

            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0]; //General
            //click group to delete
            int i = 0;
            foreach (TreeNode item in root.Nodes) // each node in General list
            {
                FocusGroup(groupToDelete, item);
            }

            dialog.Get<Button>("uxDeleteAddressButton").Click(); //Click na delete
            Window deleteGroup = dialog.ModalWindow("Delete Group");
            deleteGroup.Get<RadioButton>().Click();


            //RadioButton1 uxDeleteAllRadioButton   delete all data
            //Radiobutton2 uxDeleteGroupsOnlyRadioButton   Move contacts before group and subgroup deleting

            CloseGroupsDialog(dialog);
        }

        public void FindAndFocusItemInTree(TreeNode root, GroupData groupToDelete)
        {
            foreach (TreeNode item in root.Nodes) // each node in General list
            {
                FocusGroup(groupToDelete, item);
            }

        }

        public void FocusGroup(GroupData groupToDelete, TreeNode item)
        {
            if (item.Text == groupToDelete.Name)
            {
                item.Focus();
                //or Click???
            }
            else
            {
                if (item.Nodes.Count > 0)
                {
                    
                    FindAndFocusItemInTree(item, groupToDelete);
                }
            }
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();

            manager.MainWindow.Get<Button>("uxNewAddressBu").Click();
            //TextBox textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            //dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            //textBox.Enter(newGroup.Name);
            TestStack.White.InputDevices.Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialog(dialog);
        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE); 
        }

        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }
    }
}