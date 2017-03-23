// 初始化
L.Core = function (map) {
    // 加载底图 天地图 http://t2.tianditu.cn/DataServer?T=vec_w&X={x}&Y={y}&L={z}
    var _tianditu = L.tileLayer('http://192.168.128.1/tiles/TileService.svc/tianditu/{x}/{y}/{z}', {
        maxNativeZoom: 18,
        maxZoom: 18,
    });
    // 天地图注记 http://t2.tianditu.cn/DataServer?T=cva_w&X={x}&Y={y}&L={z}
    var _tianditulabels = L.tileLayer('http://192.168.128.1/tiles/TileService.svc/tianditulabel/{x}/{y}/{z}', {
        maxNativeZoom: 18,
        maxZoom: 18,
    });
    var _tianditugroups = L.layerGroup([_tianditu, _tianditulabels]);
    // 谷歌底图 http://mt3.google.cn/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}
    var _googlesatellite = L.tileLayer('http://192.168.128.1/tiles/TileService.svc/raster/{x}/{y}/{z}', {
        maxNativeZoom: 18,
        maxZoom: 22,
    });
    // 谷歌DEM http://mt1.google.cn/vt/lyrs=t@130&hl=zh-cn&gl=cn&src=app&x={x}&y={y}&z={z}
    var _googledem = L.tileLayer('http://192.168.128.1/tiles/TileService.svc/terrain/{x}/{y}/{z}', {
        maxNativeZoom: 18,
        maxZoom: 22,
    });
    // 底图
    var basemaps = {
        "天地图": _tianditugroups,
        "影像图": _googlesatellite,
        "地形图": _googledem
    };

    // 数据图层
    this._lw = L.esri.dynamicMapLayer({
        url: 'http://202.103.225.217:6080/ArcGIS/rest/services/PANOMAPS/MapServer',
        opacity: 0.7,
        useCors: false,
        layers: [0],
        //layerDefs: { 1: "CODE='R2'" }
    });
    // 数据图层
    this._xzqh = L.esri.dynamicMapLayer({
        url: 'http://202.103.225.217:6080/ArcGIS/rest/services/PANOMAPS/MapServer',
        opacity: 1,
        useCors: false,
        layers: [1],
        //layerDefs: { 1: "CODE='R2'" }
    });

    var overlays = {
        "行政区划": this._xzqh,
        "路网": this._lw
    };

    var layerControl = L.control.layers(basemaps, overlays, {
        position: 'topright',
        autoZIndex: true
    }).addTo(map);

    _googlesatellite.addTo(map);    // 默认加载谷歌底图


    return this;
};