var express = require('express')
var WebSocket  = require('ws');
var app = express()
var server = require("http").Server(app)
var io = require('socket.io')(server)
var port = 3000;
const wss = new WebSocket.Server({ port }, ()=>{
    console.log("Server started")
});

var Round = require("./models/Round")

let response = {
    code: 200,
    message: "OK",
    data: {}
}

// server.listen(port)

const mongoose = require('mongoose');
// user : bigsmall / hNZrf9HhXsMVteEr
mongoose.connect('mongodb+srv://bigsmall:hNZrf9HhXsMVteEr@cluster0.4iziy.mongodb.net/?retryWrites=true&w=majority', (e) => {
    if (e) {
        console.log("Mongoose connection error: " + e)
    } else {
        console.log("Mongoose connection established")
    }
});

var currentRoundNumber = null;
function createNewRound() {
    var newRound = new Round({
        small_money: 1000,
        small_players: 0,
        big_money: 500,
        big_players: 10,
        counter: 0,
        result: -1,
        dateCreated: Date.now()
    })
    newRound.save((e) => {
        if (!e) {
            console.log("New round created : " + newRound.roundNumber)
            currentRoundNumber = newRound.roundNumber
            roundCounter(currentRoundNumber)
        } else {
            currentRoundNumber = null;
        }
    })
}
function roundCounter(roundNumber) {
    Round.findOne({ roundNumber }, (e, round) => {
        if (!e && round != null) {
            if (round.counter < 10) {
                round.counter++;
                round.small_money += Math.floor(Math.random() * 3000)
                round.big_money += Math.floor(Math.random() * 3000)
                console.log(`Current round : ${currentRoundNumber} , count : ${round.counter}`)
                round.save((eSave) => {
                    
                    setTimeout(() => {
                        roundCounter(roundNumber);
                    }, 1000)
                })
            } else {
                round.result = Math.floor(Math.random() * 2);
                if (round.result == 0) {
                    round.dice = Math.floor(Math.random() * 3) + 1;
                } else {
                    round.dice = Math.floor(Math.random() * 3) + 4;
                }
                round.save((eSave) => {
                    console.log("Winner is : " + round.result)
                    setTimeout(() => {
                        createNewRound()
                    }, 1000)
                })
            }
        } else {
            // Have error or not found any round 
        }
    })
}

createNewRound()

wss.getUniqueID = function () {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }
    return s4() + s4() + '-' + s4();
};
wss.broadcast = function broadcast(msg) {
    wss.clients.forEach(function each(client) {
        client.send(msg);
     });
 };

wss.on('connection', function connection(ws, req) {
    ws.id = wss.getUniqueID();
    console.log("New WS connection established : " + ws.id);
    ws.on('message', (data) => {
        data = data.toString();
        console.log("Message received : ", data)
        response.message = data;
        ws.send(JSON.stringify(response))
    });

    wss.broadcast('Welcome to connect Web Socket Server');
});

wss.on("listening", () => {
    console.log("Server listening on " + port)
})
// io.on("connection", function(socket){
//     console.log("New connection established : " + socket.id);
//     socket.on("message", (data)=>{
//         console.log("Message received : " + data)
//         socket.send(data)
//     })
//     socket.on("disconnect", function(){
//         console.log("Connection closed : " + socket.id);
//     })
// })
