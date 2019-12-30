import React from 'react';

class Modal extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {

        if (!this.props.isOpen) {
            return null;
        }

        let bird = this.props.bird;

        return (
            <div className="modal">
                <div className="modalImageWrapper">
                    <img className="modalImage" src={this.props.image}/>
                </div>
                <h2 className="modalTitle">
                    {bird.name}
                </h2>
                <div className="modalText">
                    {bird.description}
                </div>
            </div>
        );
    }
}

export default Modal;
