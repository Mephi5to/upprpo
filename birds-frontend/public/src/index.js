import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import store from './store'
import Item from "./item";
import Modal from './modal/modal'
import ModalBackground from "./modal/modal_background";

class App extends React.Component {

    constructor() {
        super();
        this.state = store.state;
    }

    render() {
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
