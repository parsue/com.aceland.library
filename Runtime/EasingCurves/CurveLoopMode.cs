namespace AceLand.Library.EasingCurves
{
    public enum CurveLoopMode
    {
        // Do not clamp or wrap. t can be any value.
        Once = 0,

        // Clamp t into [0,1].
        Clamp = 1,

        // Wrap t to [0,1] repeating (… 0->1 -> 0->1 …).
        Loop = 2,

        // Ping-pong t between 0 and 1 (… 0->1->0->1 …).
        PingPong = 3,
    }
}