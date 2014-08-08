//Contains tile size and scene layout details
var sceneLayoutService = function () {
    var width,
        get = function () {
            width = $('#content').width();

            //scene1
            var pad = 6,
            r1H = 210,
            //small
            s1Sh = 93,
            s1Sh2 = 93,
            s1Sw = 264,
            //medium
            s1Mh = 197,
            s1Mw = 365,
            s1Mw2 = 270,
            //large
            s1Lh = 340,
            s1Lw = 584,

            items = { tiles:
                    [
                    { name: 'Account Details',
                        tileId: 'AccountDetails',
                        formatter: tileFormatter.formatAccountDetails,
                        scenes: [
                            { height: s1Mh, width: s1Mw, top: 0, left: 0, opacity: 1, size: 1, borderColor: '#5E1B6B', z: 0 },
                            { height: 90, width: 210, top: 80, left: 250, size: 0, borderColor: '#5E1B6B', z: '2000', opacity: .5 }
                        ]
                    },
                    { name: 'Video',
                        tileId: 'Video',
                        formatter: tileFormatter.formatVideo,
                        scenes: [
                            { height: s1Mh, width: s1Mw2, top: 0, left: s1Mw + pad, opacity: 1, size: 1, borderColor: '#EF7632', z: 0 },
                            { height: 200, width: 280, top: 0, left: 500, size: 1, borderColor: '#EF7632', z: '10000', opacity: 1 }
                        ]
                    },

                    { name: 'DOW',
                        tileId: 'DOW',
                        formatter: tileFormatter.formatMarketData,
                        chartColor: 'green',
                        scenes: [
                            { height: s1Sh, width: s1Sw, top: 0, left: s1Mw + s1Mw2 + (pad * 2), opacity: 1, size: 0, borderColor: '#CE0810', z: 0 },
                            { height: 90, width: 200, top: 60, left: 870, size: 0, borderColor: '#CE0810', opacity: .7 }
                        ]
                    },
                    { name: 'NASDAQ',
                        tileId: 'NASDAQ',
                        formatter: tileFormatter.formatMarketData,
                        chartColor: 'red',
                        scenes: [
                            { height: s1Sh2, width: s1Sw, top: s1Sh + (pad * 1.8), left: s1Mw + s1Mw2 + (pad * 2), opacity: 1, size: 0, borderColor: '#CE0810', z: 0 },
                            { height: 105, width: 250, top: 200, left: 0, size: 0, borderColor: '#CE0810', opacity: .65, z: '2000' }
                        ]
                    },
                    { name: 'SP500',
                        tileId: 'SP500',
                        formatter: tileFormatter.formatMarketData,
                        chartColor: null,
                        scenes: [
                            { height: s1Sh, width: s1Sw, top: 0, left: s1Mw + s1Mw2 + s1Sw + (pad * 3), opacity: 1, size: 0, borderColor: '#CE0810', z: 0 },
                            { height: 100, width: 260, top: 430, left: 525, size: 0, opacity: .45, z: '1000', borderColor: '#00324B' }
                        ]
                    },
                    { 'name': 'Sector Summary',
                        'tileId': 'SectorSummary',
                        'scenes': [
                            { height: s1Sh2, width: s1Sw, top: s1Sh + (pad * 1.8), left: s1Mw + s1Mw2 + s1Sw + (pad * 3), opacity: 1, size: 0, borderColor: '#00A600', z: 0 },
                            { height: 155, width: 280, top: 220, left: 620, size: 0, borderColor: '#00A600', opacity: .65 }
                        ]
                    },
                    { name: 'Market News',
                        tileId: 'MarketNews',
                        scenes: [
                            { height: s1Mh, width: s1Mw, top: 0, left: s1Mw + s1Mw2 + (s1Sw * 2) + (pad * 4), opacity: 1, size: 1, borderColor: '#3749A9', z: 0 },
                            { height: 225, width: 350, top: 270, left: 850, size: 0, borderColor: '#3749A9', opacity: .9 }
                        ]
                    },
                    { name: 'Currencies',
                        tileId: 'Currencies',
                        scenes: [
                            { height: s1Mh, width: s1Mw2, top: 0, left: (s1Mw * 2) + s1Mw2 + (s1Sw * 2) + (pad * 5), opacity: 1, size: 1, borderColor: '#00F277', z: 0 },
                            { height: 140, width: 220, top: 370, left: 115, size: 0, borderColor: '#00F277', opacity: .35 }
                        ]
                    },

                    { name: 'Quotes',
                        tileId: 'Quote',
                        formatter: tileFormatter.formatQuote,
                        scenes: [
                            { height: s1Lh, width: s1Lw, top: r1H, left: 0, opacity: 1, size: 2, borderColor: '#00324B', z: 0 },
                            { height: 205, width: 270, top: 240, left: 305, size: 1, borderColor: '#CE0810', opacity: .85, z: '5000' }
                        ]
                    },

                    { name: 'Account Positions',
                        tileId: 'AccountPositions',
                        formatter: tileFormatter.formatAccountPositions,
                        scenes: [
                            { height: s1Lh, width: s1Lw, top: r1H, left: 592, opacity: 1, size: 2, borderColor: '#5DBBC0', z: 0 },
                            { height: 90, width: 195, top: 40, left: 58, size: 0, borderColor: '#5DBBC0', opacity: .2, z: '100' }
                        ]
                    }

                ]
            };

        return items;
    };
    
    return {
        get: get
    };

} ();