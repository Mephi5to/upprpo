import React from 'react';
import axios from "axios";
import config from "./config";

class Item extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            imageUrl: props.bird.imageUrl,
            audioUrl: props.bird.audioUrl
        };

        axios({
            method: 'get',
            url: config.apiUrl + config.filesUrl + props.bird.imageUrl,
            responseType: 'json'
        })
            .then(res => {
                this.setState({
                    imageUrl: 'data:image/gif;base64,' + res.data.data
                })
            })
            .catch(res => {
            });

        axios({
            method: 'get',
            url: config.apiUrl + config.filesUrl + props.bird.audioUrl,
            responseType: 'json'
        })
            .then(res => {
                this.setState({
                    audioUrl: 'data:audio/mp3;base64,' + res.data.data
                })
            })
            .catch(res => {
            });
    }

    render() {
        return <div onClick={() => {
            this.props.setSelectedBirdFunc(this.props.bird);
        }} className="item">
            <div className="horizont_float">
                <ItemImage imageUrl={this.state.imageUrl}></ItemImage>
            </div>
            <div className="item_body">
                <ItemHeader name={this.props.bird.name}></ItemHeader>
                <ItemAudio audioUrl={this.state.audioUrl}></ItemAudio>
            </div>
        </div>
    }
}

const ItemHeader = (props) => {
    return <h2 id={props.id} className="bird_name">
        <span className="bird_name_text">{props.name}</span>
    </h2>
};

const ItemImage = (props) => {
    return <img className="image" src={props.imageUrl}/>
};

const ItemAudio = (props) => {
    return <div className="audio_item">
        <audio controls className="audio" src={props.audioUrl}>
        </audio>
    </div>
};

export default Item;