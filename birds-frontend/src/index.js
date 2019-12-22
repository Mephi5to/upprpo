import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import store from './store'
import Item from "./item";
import Modal from './modal/modal'
import ModalBackground from "./modal/modal_background";
import axios from 'axios';
import config from './config';

const FILES_URL = '/api/v1/files/';
const BIRDS_URL = `/api/v1/birds`;

class App extends React.Component {

    constructor() {
        super();
        this.state = store.state;
    }

    render() {
        window.scrollTo(0, -100);
        return <div>
            <Body
                birdsListProps={this.state.birdsList}
                setSelectedBirdFunc={this.setSelectedBird}
                setModalIsOpenFunc={this.setModalIsOpen}>
            </Body>
            <Modal
                isOpen={this.state.modalIsOpen}
                onClose={() => this.setState({
                    modalIsOpen: false
                })}
                bird={this.state.selectedBird}>
            </Modal>
            <ModalBackground
                isOpen={this.state.modalIsOpen}
                onClose={() => this.setState({
                    modalIsOpen: false
                })}>
            </ModalBackground>
        </div>
    };

    componentDidMount() {
        axios({
            method: 'get',
            url: config.apiUrl + BIRDS_URL,
            responseType: 'json'
        })
            .then(res => {

                let newBirdsList = [];

                for (let i = 0; i < res.data.birds.length; i++) {
                    let bird_from_api = res.data.birds[i];
                    let bird = {
                        id: bird_from_api.id,
                        name: bird_from_api.name,
                        description: bird_from_api.description,
                        imageUrl: FILES_URL + bird_from_api.imageFileId,
                        audioUrl: FILES_URL + bird_from_api.audioField
                    };
                    newBirdsList.push(bird);
                }


                this.setState({
                    birdsList: newBirdsList
                });
            })
            .catch(res => {
            })
    }

    setModalIsOpen = (value) => {
        this.setState({
            modalIsOpen: value
        })
    };

    setSelectedBird = (bird) => {
        this.setState({
            selectedBird: bird
        })
    };
}

const Body = (props) => {
    return <div>
        {props.birdsListProps.map((bird) =>
            <Item
                bird={bird}
                setSelectedBirdFunc={props.setSelectedBirdFunc}
                setModalIsOpenFunc={props.setModalIsOpenFunc}>
            </Item>)
        }
    </div>
};


ReactDOM.render(<App/>, document.getElementById('root'));
