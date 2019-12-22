import React from 'react';
import store from '../store'

class ModalBackground extends React.Component {

    constructor(props) {
        super(props);
        this.state = store.state;
    }

    render() {

        if (!this.props.isOpen) {
            return null;
        }

        return (
            <div className="bg" onClick={e => this.close(e)} />
        );
    }

    close(e) {
        e.preventDefault();
        if (this.props.onClose) {
            this.props.onClose();
        }
    }
}

export default ModalBackground;
