using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PanoClient
{

    public abstract class CustomProviderBase : GMapProvider
    {
        public CustomProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://www.lzdodo.com/";
            Copyright = string.Format("©{0} DoDo , ©{1}", DateTime.Today.Year, "柳州勘测院");    
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get {
                if (overlays == null) {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomProvider : CustomProviderBase
    {
        public static readonly CustomProvider Instance;

        readonly Guid id = new Guid("e2195240-fd9a-11e6-a7a3-000c29fdb390");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "CustomMAP";
        public override string Name
        {
            get { return name; }
        }
        static CustomProvider()
        {
            Instance = new CustomProvider();
        }
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            try {
                string url = MakeTileImageUrl(pos, zoom, LanguageStr);
                return GetTileImageUsingHttp(url);
            }
            catch (Exception ex) { return null; }
        }

        private string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            string url = string.Format(UrlFormat, pos.X, pos.Y, zoom);
            return url;
        }

        static readonly string UrlFormat = ConfigurationManager.AppSettings["mapurl"];
    }
}
