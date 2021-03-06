var cluster = function () {
    network.on("selectNode", function (params) {
        if (params.nodes.length == 1) {
            if (network.isCluster(params.nodes[0]) == true) {
                network.openCluster(params.nodes[0]);
            }
        }
    });


    var count = 0;
    return function (query) {
        count++;
        var teamStyle = {
                borderWidth: 3,
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf1ae',
                    size: 50,
                    color: '#57169a'
                },
                label: 'Team'
            },
            clusterOptionsByData = {
                joinCondition: function (nodeOption) {
                    if (Array.isArray(nodeOption)) {
                        for (var j = 0; j < nodeOption.length; j++) {
                            if (nodeOption[query.prop][j] === query.value) {
                                console.log(nodeOption);
                                return true;
                            }
                        }
                        return false;
                    }
                    console.log(nodeOption);
                    return nodeOption[query.prop] === query.value;
                },
                clusterNodeProperties: {
                    id: 'cluster' + count,
                    borderWidth: 3,
                    shape: 'icon',
                    icon: {
                        face: 'FontAwesome',
                        code: '\uf1ae',
                        size: 50,
                        color: '#57169a'
                    },
                    label: 'Team'
                }
        };
        network.cluster(clusterOptionsByData);
        network.clusterByConnection(clusterOptionsByData.clusterNodeProperties.id, {clusterNodeProperties: teamStyle});
    }
};