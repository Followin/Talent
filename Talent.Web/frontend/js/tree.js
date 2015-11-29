// create an array with nodes
var DIR = "./";


var result;

$.ajax(
    {
        type: "GET",
        url: "http://localhost:50408/socials/info",
        success: function (data, statusText) {
            result = data;
            window.edges = new vis.DataSet(result.edges);
            window.nodes = new vis.DataSet(result.nodes);



            // create a network
            var container = document.getElementById('tree-network');

            var data = {
                nodes: nodes,
                edges: edges
            };

            var options = {
                height: window.innerHeight - 60 + "px",
                groups: {
                    useDefaultGroups: true,
                    user: {
                        shape: "circularImage"
                    }
                }
            };
            window.network = new vis.Network(container, data, options);

            //cluster.js
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
                                shape: 'circle',
//                                icon: {
//                                    face: 'FontAwesome',
//                                    code: '\uf1ae',
//                                    size: 50,
//                                    color: '#57169a'
//                                },
                                label: query.value
                            }
                        };
                    network.cluster(clusterOptionsByData);
//                    network.clusterByConnection(clusterOptionsByData.clusterNodeProperties.id, { clusterNodeProperties: teamStyle });
                }
            };

            cluster = cluster();
            cluster({ prop: 'project', value: 'd0' });

            //aside.js
            var hobbysTemplate = _.template($("#hobbys-item").html());
            var skillsTemplate = _.template($("#skills-item").html());
            var peopleTemplate = _.template($("#people-item").html());

            function renderUserAside(node) {
                $('#user-photo').attr("src", node.image);
                $('#user-name').html(node.title);

                $('#skype-link').attr("href", "callto://" + node.skype);
                $('#skype-text-link').html(node.skype);

                /*    $('#tel-link').attr("href", "tel://" + node.phone);
                    $('#tel-text-link').html(node.phone);*/

                $('#email-link').attr("href", "mailto://" + node.email);
                $('#email-link-text').html(node.email);

                $('#hobby-name').html(node.title);
            }



            network.on("selectNode", function (params) {
                var rootNode = nodes.get(params.nodes[0]);
                var connectedNodesID = network.getConnectedNodes(params.nodes[0]);
                renderUserAside(rootNode);
                if (rootNode.group === "user") {
                    $("#hobby-profile").addClass("hide");
                    $("#user-profile").removeClass("hide");
                    var connectedHobbys = [];
                    var connectedSkills = [];
                    for (var i = 0, length = connectedNodesID.length; i < length; i++) {
                        var item = nodes.get(connectedNodesID[i]);
                        if (item.group === "interest") {
                            connectedHobbys.push(item);
                        }
                        else {
                            connectedSkills.push(item);
                        }
                    }
                    $("#hobbys-list").html(hobbysTemplate({ items: connectedHobbys }));
                    $("#skills-list").html(skillsTemplate({ items: connectedSkills }));
                }
                else {
                    $("#user-profile").addClass("hide");
                    $("#hobby-profile").removeClass("hide");
                    var connectedPeople = [];
                    for (var i = 0, length = connectedNodesID.length; i < length; i++) {
                        connectedPeople.push(nodes.get(connectedNodesID[i]));
                    }
                    $("#people-list").html(peopleTemplate({ items: connectedPeople }));
                }
            });
        }
    }
);