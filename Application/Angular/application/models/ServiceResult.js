function ServiceResult(success, data) {
    this.success = success;
    this.data = data;
};


ServiceResult.prototype.isSuccess = function () {
    return this.success;
}
