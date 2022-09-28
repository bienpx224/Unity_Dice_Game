# Game Tài Xỉu 

## Công nghệ sử dụng : 
- Nodejs : Tạo server, kết nối DB Mongo, CRUD model. Tạo kết nối Web Socket để bắn dữ liệu realtime cho Client. Tạo logic kết quả trò chơi, thông tin vòng chơi và trả về cho Clients.
- Mongo DB : Đang sử dụng mongo online trên trang chủ, bằng tk gmail bienpx224. Config user/pass ở trong file server.js 
- Unity : Thực hiện kết nối và lắng nghe tín hiệu socket từ server. Thiết kế UI và logic để vận hành quá trình chơi game.
- Link cài package Nuget cho Unity : https://github.com/bienpx224/NuGetForUnity 
- Link cài Web Socket Sharp : https://www.youtube.com/watch?v=13HnJPstnDM
- Random number : ```return Random.Range(0, maxNumber) + minNumber;```
- Design Pattern : Singleton pattern, Observer pattern.
## Lưu ý : 
- Do phía Unity nếu để sử dụng package best http2 để kết nối socketio đồng bộ với socketio như trên server thì tốn kém vì package best http2 tốt nhưng mất tiền để mua =))) sau vào dự án thì hẵng mua.
=> Hiện tại đang sử dụng websocket thuần để kết nối và lắng nghe message từ server, cũng như bắn tín hiệu lên server. Vì websocket là thuần nên việc code khá là tù, ko có channel, emit, bắn event tới các client lắng nghe cụ thể rõ ràng hơn. Vậy nên đã phải tự viết 1 số function để bắn nhận tín hiệu và truyền data là convert sang string để endpoint đọc dữ liệu và dựa vào đó để sử lý. 
- Về quá trình thực hiện thì do cũng ko có gì quá phức tạp nên đã ko viết Step by step.

## Hướng dẫn sử dụng trước khi dùng : 
- Đã để sẵn project server để chạy tính toán, lưu DB và bắn socket về Client ở trong project này.
- Mở terminal ở folder ServerGameTaiXiu : 
    ``` 
    npm i
    node server.js   // để khởi chạy server
    ```
- Nếu muốn điều chỉnh logic gì ở trong file server.js
- Sau đó chạy project Unity này lên, play thôi là được rồi. 
## Định hướng tương lai : 
- Viết Smartcontract để tạo token riêng, sử dụng mạng ETH testet (Rinkeby) deploy bằng hardhat, dùng để bet trong game, gồm các func chính : Mint, Buy, Transfer, Burn, SafeTransfer, GetInfoAddress.
- Trong Unity, thực hiện việc kết nối wallet (web3) metamask. 
- Thực hiện việc call func của contract.
- Lưu trữ thông tin địa chỉ ví, số lượng token của user ở trên blockchain, ko lưu ở phía server để thử decentralize toàn bộ. 
- Hoàn thiện tính năng gameplay để cho user có thể thực sự mua token, dùng token để bet trong game, earn token khi chiến thắng và mất token khi thua be bét =)) 
- Mỗi khi kết thúc 1 Round game, tính toán chia lợi nhuận cho các user, 10% sẽ được chia cho địa chỉ ví của mình (Comission) =)) ăn tiền hoa hồng thế là đủ thơm rồi.
=> Conclusion : Go to the jail  =)) 

#### Thanks for watching this. 