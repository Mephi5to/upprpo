import React from 'react';
import axios from 'axios';
import config from "../config";

class AddBirdForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            warningEnabled: false
        };
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
                        <label htmlFor="name">Название*</label>
                        <input id="name"
                               className="nameInput"
                               type="text"
                               name="name" required/>
                    </div>
                    <div className="birdDescription">
                        <label className="descriptionLabel"
                               htmlFor="name">Описание*</label>
                        <textarea id="descr"
                                  className="descriptionInput"
                                  name="name" required/>
                    </div>
                    <div className="birdImageInput">
                        <label htmlFor="name">Изображение*</label>
                        <input id="img"
                               className="fileInput"
                               type="file"
                               name="name" required/>
                    </div>
                    <div className="birdAudioInput">
                        <label htmlFor="name">Запись голоса*</label>
                        <input id="audio"
                               className="fileInput"
                               type="file"
                               name="name" required/>
                    </div>
                    <Warning enabled={this.state.warningEnabled}>
                    </Warning>
                </div>

                <div className="addBirdFormButtons">
                    <div className="formButton"
                         onClick={() => {
                             this.setWarningEnabled(false);
                             this.props.closeFormFunc();
                         }}>
                        <span className="buttonTextCancel">Отмена</span>
                    </div>
                    <div className="formButton"
                         onClick={() => {
                             this.addBird();
                         }}>
                        <span className="buttonTextCreate">Добавить</span>
                    </div>
                </div>
            </div>
        );
    }

    addBird() {

        let name = document.getElementById("name").value;
        let description = document.getElementById("descr").value;
        let image = document.getElementById("img").files;
        let audio = document.getElementById("audio").files;

        if (!name || name.length < 1 || !description || description.length < 1 || !image || !audio) {
            this.setWarningEnabled(true);
            return null;
        }

        let imageElement = image[0];
        let audioElement = audio[0];

        var reader = new FileReader();

        reader.readAsDataURL(imageElement);

        reader.onload = (event) => {

            let result = event.target.result;
            let startWith = result.indexOf('base64,') + 7;

            let data = result.substring(startWith);

            axios({
                method: 'post',
                url: config.apiUrl + config.filesUrl,
                responseType: 'json',
                data: {
                    name: name + '_image',
                    data: data
                }
            }).then(res => {

                this.setImageId(res.data.id);

                reader.readAsDataURL(audioElement);
                reader.onload = (event) => {

                    let result = event.target.result;
                    let startWith = result.indexOf('base64,') + 7;

                    let data = result.substring(startWith);

                    axios({
                        method: 'post',
                        url: config.apiUrl + config.filesUrl,
                        responseType: 'json',
                        data: {
                            name: name + '_audio',
                            data: data
                        }
                    }).then(res_1 => {

                        axios({
                            method: 'post',
                            url: config.apiUrl + config.birdsUrl,
                            responseType: 'json',
                            headers: {'Content-Type': 'application/json'},
                            data: {
                                items: [
                                    {
                                        name: name,
                                        description: description,
                                        imageFileId: this.state.imageId,
                                        audioFileId: res_1.data.id
                                    }
                                ]
                            }
                        }).then(res_2 => {
                            this.props.closeFormFunc();
                        }).catch(res => {
                            this.props.closeFormFunc();
                        })
                    })
                }
            })
        };
    }

    setWarningEnabled = (value) => {
        this.setState({
            warningEnabled: value
        })
    };

    setImageId = (value) => {
        this.setState({
            imageId: value
        })
    };
}

const Warning = (props) => {

    if (!props.enabled) {
        return null;
    }

    return <div className="warning">
        Пожалуйста, заполните все обязательные поля, которые отмечены *
    </div>;
};

export default AddBirdForm;
