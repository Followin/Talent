var hobbysTemplate = _.template($("#hobbys-item").html());
var skillsTemplate = _.template($("#skills-item").html());
var peopleTemplate = _.template($("#people-item").html());

function renderUserAside(node) {
    console.log(node)
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
    if(rootNode.group==="user") {
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
        
        $("#hobbys-list").html(hobbysTemplate({items: connectedHobbys}));
        $("#skills-list").html(skillsTemplate({items: connectedSkills}));
    }
    else {
        $("#user-profile").addClass("hide");
        $("#hobby-profile").removeClass("hide");
        var connectedPeople = [];
        for (var i = 0, length = connectedNodesID.length; i < length; i++) {
            connectedPeople.push(nodes.get(connectedNodesID[i]));
        };
        $("#people-list").html(peopleTemplate({items: connectedPeople}));
    }
});