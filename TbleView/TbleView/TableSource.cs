using System;
using Foundation;
using UIKit;

namespace TbleView
{
    public class TableSource : UITableViewSource
    {

        protected string[] tableItems;
        protected string cellIdentifier = "TabvleCell";
        ViewController owner;


        public TableSource(string[] data,ViewController owner)
        {
            tableItems = data;
            this.owner = owner;
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //request to a cell to save memory 
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

            // if there no cels to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = tableItems[indexPath.Row];
            return cell;
         }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIAlertController alertController = UIAlertController.Create("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));
            owner.PresentViewController(alertController,true,null);

            UIApplication.SharedApplication.OpenUrl(new NSUrl("https:/www.google.com/#q="+tableItems[indexPath.Row]));
            tableView.DeselectRow(indexPath, true);
        }



    }
}
