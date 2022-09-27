const mongoose = require('mongoose');
const AutoIncrement = require('mongoose-sequence')(mongoose);
const roundSchema = new mongoose.Schema({
    small_money : Number,
    small_players : Number,
    big_money : Number,
    big_players : Number,
    counter : Number,  // 1 -> 60 seconds thoi gian ra ket qua 
    result : Number, // -1 : waiting, 0 small, 1 big
    dice : Number,  //  if result is 0 -> dice is from 1 to 3, if rs = 1 -> dice is from 4 to 5
    dateCreated : Date
})
roundSchema.plugin(AutoIncrement, {inc_field: "roundNumber"})
module.exports = mongoose.model('round', roundSchema)