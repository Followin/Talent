// create an array with nodes
var DIR = "./";

var nodes = new vis.DataSet([
    {
        id: "1",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "2",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "3",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "4",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "5",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "6",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "7",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "8",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "9",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "10",
        img: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "11",
        value: 31,
        img: null,
        title: "Популярная музыка",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "12",
        value: 11,
        img: null,
        title: "Баскетбол",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "13",
        value: 31,
        img: null,
        title: "Футбол",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "14",
        value: 16,
        img: null,
        title: "Классическая музыка",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "15",
        value: 58,
        img: null,
        title: "Бокс",
        group: "interest",
        email: null,
        skype: null
    }
]);

// create an array with edges
var edges = new vis.DataSet([
    {
        from: "1",
        to: "11"
    },
    {
        from: "1",
        to: "14"
    },
    {
        from: "1",
        to: "15"
    },
    {
        from: "2",
        to: "13"
    },
    {
        from: "3",
        to: "14"
    },
    {
        from: "3",
        to: "12"
    },
    {
        from: "4",
        to: "13"
    },
    {
        from: "4",
        to: "12"
    },
    {
        from: "5",
        to: "11"
    },
    {
        from: "6",
        to: "11"
    },
    {
        from: "6",
        to: "12"
    },
    {
        from: "6",
        to: "13"
    },
    {
        from: "6",
        to: "14"
    },
    {
        from: "6",
        to: "15"
    },
    {
        from: "6",
        to: "12"
    },
    {
        from: "6",
        to: "13"
    },
    {
        from: "8",
        to: "11"
    },
    {
        from: "8",
        to: "15"
    },
    {
        from: "9",
        to: "11"
    },
    {
        from: "10",
        to: "13"
    }
]);

// create a network
var container = document.getElementById('tree-network');

//    $("#mynetwork").height(window.height - 60);
var data = {
    nodes: nodes,
    edges: edges
};

var options = {
    height: window.innerHeight - 60 + "px",
    groups: {
        useDefaultGroups: true,
        user: {
/*            shape: "circularImage" */
        }
    }
};
var network = new vis.Network(container, data, options);
network.on("selectNode", function(params) {
    nodes.clear();
    nodes.add([
        {
            id: "a8532967-b695-e511-9bf9-6c71d968fe62",
            value: 28,
            img: null,
            title: "Классическая музыка",
            group: "interest",
            email: null,
            skype: null
        },
        {
            id: "a9532967-b695-e511-9bf9-6c71d968fe62",
            value: 51,
            img: null,
            title: "Поэзия",
            group: "interest",
            email: null,
            skype: null
        },
        {
            id: "aa532967-b695-e511-9bf9-6c71d968fe62",
            value: 66,
            img: null,
            title: "Популярная музыка",
            group: "interest",
            email: null,
            skype: null
        }
    ])
});