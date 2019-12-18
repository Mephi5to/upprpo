import React, {useState} from 'react';

const Item = (props) => {

    return <div onClick={() => {
        props.setSelectedBirdFunc(props.bird);
    }} className="item">
        <div className="horizont_float">
        </div>
        <div className="item_body">
        </div>
    </div>
};

export default Item;