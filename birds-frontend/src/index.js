import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import store from './store'
import Item from "./item";
import Modal from './modal/modal'
import ModalBackground from "./modal/modal_background";
import axios from 'axios';
import config from './config';
import OpenForm from "./add_bird/open_form";
import AddBirdForm from "./add_bird/add_bird_form";

class App extends React.Component {

    constructor() {
        super();
        this.state = store.state;
    }

    render() {
        window.scrollTo(0, -100);
        return <div>
            <Body
                enabled={this.state.bodyEnabled}
                birdsListProps={this.state.birdsList}
                setSelectedBirdFunc={this.setSelectedBird}
                setModalIsOpenFunc={this.setModalIsOpen}>
            </Body>
            <OpenForm
                enabled={this.state.openFormButtonEnabled}
                openFormFunc={this.openForm}>
            </OpenForm>
            <AddBirdForm
                enabled={this.state.addBirdFormEnabled}
                closeFormFunc={this.closeAddBirdForm}>
            </AddBirdForm>
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
            url: config.apiUrl + config.birdsUrl,
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
                        imageUrl: config.filesUrl + bird_from_api.imageFileId,
                        audioUrl: config.filesUrl + bird_from_api.audioField
                    };
                    newBirdsList.push(bird);
                }

                // this.setState({
                //     birdsList: newBirdsList
                // });
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

    setBodyEnabled = (value) => {
        this.setState({
            bodyEnabled: value
        })
    };

    setOpenFormEnabled = (value) => {
        this.setState({
            openFormButtonEnabled: value
        })
    };

    setAddBirdFormEnabled = (value) => {
        this.setState({
            addBirdFormEnabled: value
        })
    };

    closeAddBirdForm = () => {
        this.setAddBirdFormEnabled(false);
        this.setBodyEnabled(true);
        this.setOpenFormEnabled(true);
    };

    openForm = () => {
        this.setOpenFormEnabled(false);
        this.setBodyEnabled(false);
        this.setAddBirdFormEnabled(true);
    };
}

const Body = (props) => {

    if (!props.enabled) {
        return null;
    }

    return <div>
        {props.birdsListProps.map((bird) =>
            <Item
                bird={bird}
                setSelectedBirdFunc={props.setSelectedBirdFunc}
                setModalIsOpenFunc={props.setModalIsOpenFunc}>
            </Item>)
        }
    </div>;
};


ReactDOM.render(<App/>, document.getElementById('root'));
