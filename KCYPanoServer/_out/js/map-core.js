
// 初始化
L.Core = function (map) {
    // 加载底图 天地图
    var _tianditu = L.tileLayer('http://t2.tianditu.cn/DataServer?T=vec_w&X={x}&Y={y}&L={z}', {
        maxNativeZoom: 18,
        maxZoom: 18,
    });
    // 天地图注记
    var _tianditulabels = L.tileLayer('http://t2.tianditu.cn/DataServer?T=cva_w&X={x}&Y={y}&L={z}', {
        maxNativeZoom: 18,
        maxZoom: 18,
    });
    var _tianditugroups = L.layerGroup([_tianditu, _tianditulabels]);

    // 谷歌底图
    var _googlesatellite = L.tileLayer('http://mt3.google.cn/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}', {
        maxNativeZoom: 18,
        maxZoom: 22,
    });
    // 谷歌DEM
    var _googledem = L.tileLayer('http://mt1.google.cn/vt/lyrs=t@130&hl=zh-cn&gl=cn&src=app&x={x}&y={y}&z={z}', {
        maxNativeZoom: 18,
        maxZoom: 22,
    });
    // 底图
    var basemaps = {
        "天地图": _tianditugroups,
        "影像图": _googlesatellite,
        "地形图": _googledem
    };


    // this._dt_reline = L.esri.dynamicMapLayer({
    //     url: 'http://www.lzdodo.com/arcgis/rest/services/BASE/MapServer',
    //     opacity: 0.7
    // });


    var overlays = {
        //"控规": this._konggui,
        //"红线": this._dt_reline
    };

    var layerControl = L.control.layers(basemaps, overlays, {
        position: 'topright',
        autoZIndex: true
    }).addTo(map);

    _googlesatellite.addTo(map);        // 默认加载谷歌底图
    //this._dt_reline.addTo(map);       // 添加红线
    //this._dt_reline.bringToBack();

    return this;
};