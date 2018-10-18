public interface IManager{
    bool CanTick();
    void Tick();
    void InitManager(object obj);
    string GetManagerType();
}