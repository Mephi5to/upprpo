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
        </div>
    }
}




ReactDOM.render(<App/>, document.getElementById('root'));


