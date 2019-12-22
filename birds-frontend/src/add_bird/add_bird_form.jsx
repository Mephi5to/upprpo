import React from 'react';

class AddBirdForm extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {

        if (!this.props.enabled) {
            return null;
        }

        return (
            <div className="addBirdForm">
                <div className="addBirdFormButtons">
                    <div className="formButton"
                         onClick={() => {
                             this.props.closeFormFunc();
                         }}>
                        <span className="buttonTextCancel">Отмена</span>
                    </div>
                    <div className="formButton">
                        <span className="buttonTextCreate">Добавить</span>
                    </div>
                </div>
            </div>
        );
    }
}

export default AddBirdForm;
