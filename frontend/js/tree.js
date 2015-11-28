// create an array with nodes
var DIR = "./";

var nodes = new vis.DataSet([
    {
        id: "1",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "2",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "3",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "4",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "5",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "d0"
    },
    {
        id: "6",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "7",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "8",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "9",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "10",
        image: "http://cs620218.vk.me/v620218901/111e6/k39Hlf7bo04.jpg",
        title: "Sergey Rud",
        group: "user",
        email: "EmailExample",
        skype: "SkypeExample",
        project: "Ad Hoc"
    },
    {
        id: "11",
        value: 31,
        image: null,
        title: "Популярная музыка",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "12",
        value: 11,
        image: null,
        title: "Баскетбол",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "13",
        value: 31,
        image: null,
        title: "Футбол",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "14",
        value: 16,
        image: null,
        title: "Классическая музыка",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "15",
        value: 58,
        image: null,
        title: "Бокс",
        group: "interest",
        email: null,
        skype: null
    },
    {
        id: "16",
        value: 58,
        image: null,
        title: "C#",
        group: "skill",
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
    },
    {
        from: "1",
        to: "16"
    },
    {
        from: "2",
        to: "16"
    },
    {
        from: "3",
        to: "16"
    },
    {
        from: "4",
        to: "16"
    },
    {
        from: "5",
        to: "16"
    },
    {
        from: "6",
        to: "16"
    }
]);

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
var network = new vis.Network(container, data, options);