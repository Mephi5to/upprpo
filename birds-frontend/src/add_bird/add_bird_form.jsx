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
                <div className="addBirtFormTitle">
                    Добавление новой птицы
                </div>

                <div className="formWrapper">
                    <div>
                        <label for="name">Название</label>
                        <input className="nameInput"
                               type="text"
                               name="name" required/>
                    </div>
                </div>

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
