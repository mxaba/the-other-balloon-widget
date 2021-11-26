import React from 'react';

const Message = (props) => (
    <div style={{ background: "#eee", borderRadius: '5px', padding: '0 10px' }}>
        <p><strong>{props.user}</strong><br/>    <i>{props.message}</i></p>
    </div>
);

export default Message;