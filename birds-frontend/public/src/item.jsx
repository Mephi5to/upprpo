import React from 'react';

const Item = (props) => {

    return <div onClick={() => {
        props.setSelectedBirdFunc(props.bird);
        props.setModalIsOpenFunc(true);
    }} className="item">
        <div className="horizont_float">
            <ItemImage imageUrl={props.bird.imageUrl}></ItemImage>
        </div>
        <div className="item_body">
            <ItemHeader name={props.bird.name}></ItemHeader>
            <ItemAudio audioUrl={props.bird.audioUrl}></ItemAudio>
        </div>
    </div>
};

const ItemHeader = (props) => {
    return <h2 id={props.id} className="bird_name">
        <span className="bird_name_text">{props.name}</span>
    </h2>
};

const ItemImage = (props) => {
    return <img className="image" src={props.imageUrl}/>
}

const ItemAudio = (props) => {
    return <div className="audio_item">
        <audio controls className="audio">
            <source src={props.audioUrl}/>
        </audio>
    </div>
}

export default Item;