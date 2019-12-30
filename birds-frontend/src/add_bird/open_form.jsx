import React from 'react';

class OpenForm extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {

        if (!this.props.enabled) {
            return null;
        }

        return (
            <div className="openForm"
                 onClick={() => {
                     this.props.openFormFunc();
                 }}>
                <h2 className="openFormTitle">
                    Добавить птицу
                </h2>
            </div>
        );
    }
}

export default OpenForm;
