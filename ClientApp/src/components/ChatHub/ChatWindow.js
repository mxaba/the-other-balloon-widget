import React from 'react';

import Message from './Message';

const ChatWindow = (props) => {
    const chat = props.chat
        .map(m => <Message 
            key={Date.now() * Math.random()}
            user={m.user}
            message={m.message}/>);

    return(
        <div style={{ overflowY: 'auto', overflowX: 'hidden', height:'40vh' }}>
            {chat}
        </div>
    )
};

export default ChatWindow;
