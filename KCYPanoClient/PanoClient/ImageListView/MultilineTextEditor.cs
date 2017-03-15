using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PanoClient.ImageListView
{
    /// <summary>
    /// 
    /// </summary>
    internal class MultilineTextEditor : UITypeEditor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try {
                IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (svc != null) {
                    if (value is string) {
                        TextBox box = new TextBox();
                        box.AcceptsReturn = true;
                        box.Multiline = true;
                        box.Height = 120;
                        box.BorderStyle = BorderStyle.None;
                        box.Text = value as string;
                        box.ScrollBars = ScrollBars.Both;
                        svc.DropDownControl(box);
                        return box.Text;
                    }
                }
            }
            catch (Exception ex) { }
            return value;
        }
    }
}
