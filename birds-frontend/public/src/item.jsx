import React, {useState} from 'react';

const Item = (props) => {

    return <div onClick={() => {
        props.setSelectedBirdFunc(props.bird);
    }} className="item">
        <div className="horizont_float">
        </div>
        <div className="item_body">
            <ItemHeader name={props.bird.name}></ItemHeader>
        </div>
    </div>
};

const ItemHeader = (props) => {
    return <h2 id={props.id} className="bird_name">
        <span className="bird_name_text">{props.name}</span>
    </h2>
};

export default Item;