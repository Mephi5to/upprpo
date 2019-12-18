import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import store from './store'
import Item from "./item";

class App extends React.Component {

    constructor() {
        super();
        this.state = store.state;
    }

    render() {
        return <div>
            <Body
                birdsListProps={this.state.birdsList}
                setSelectedBirdFunc={this.setSelectedBird}>
            </Body>
        </div>
    }

    setSelectedBird = (bird) => {
        this.setState({
            selectedBird: bird
        })
    }
}

const Body = (props) => {
    return <div>
        {props.birdsListProps.map((bird) =>
            <Item
                bird={bird}
                setSelectedBirdFunc={props.setSelectedBirdFunc}>
            </Item>)
        }
    </div>
};




ReactDOM.render(<App/>, document.getElementById('root'));
