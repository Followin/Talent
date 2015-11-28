function addNode(data) {
    try {
        nodes.add(data);
    }
    catch (err) {
        alert(err);
    }
}
function updateNode(query) {
    try {
        nodes.update(query);
    }
    catch (err) {
        alert(err);
    }
}
function removeNode(id) {
    try {
        nodes.remove({
            id: network.getSelection().nodes[0] // node will delete when node is selected
        });
    }
    catch (err) {
        alert(err);
    }
}
