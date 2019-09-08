export class InputFile {
    /**
     *
     */
    constructor(file?: File, preview?: string | ArrayBuffer) {
        this.file = file;
        this.preview = preview;
    }

    id?: any;
    file?: File;
    link?: string;
    preview?: string | ArrayBuffer;
}
