using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ChaosEngineering.Middleware
{
    /// [CHAOS GUARD v1.0]
    /// A specialized middleware designed to evaluate system RESILIENCE by injecting
    /// controlled faults, latencies, and resource pressure during the development lifecycle.
    /// Developer: yEKr00tz
    /// </summary>
    public class ChaosResilienceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ChaosResilienceMiddleware> _logger;
        private readonly Random _random = new Random();

        public ChaosResilienceMiddleware(RequestDelegate next, ILogger<ChaosResilienceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"[CHAOS GUARD] Analyzing request path: {context.Request.Path}");

            // --- SCENARIO 1: NETWORK LATENCY INJECTION ---
            // Objective: Test how the system handles slow networks or microservice timeouts.
            // Probability: 15%
            if (_random.NextDouble() < 0.15) 
            {
                int delay = _random.Next(3000, 7000); // 3 to 7 seconds delay
                _logger.LogWarning($"[LATENCY ENJECTED] Path: {context.Request.Path} delayed by {delay}ms");
                await Task.Delay(delay);
            }

            // --- SCENARIO 2: FAULT INJECTION (HTTP 500) ---
            // Objective: Verify if Error Handling mechanisms and Global Exception Handlers work as expected.
            // Probability: 5%
            if (_random.NextDouble() < 0.05) 
            {
                _logger.LogCritical($"[FAULT ENJECTED] Simulating internal server failure for {context.Request.Path}");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("ChaosGuard: Simulated system failure for resilience validation.");
                return; // Terminate the request pipeline here.
            }

            // --- SCENARIO 3: RESOURCE STRESS SIMULATION ---
            // Objective: Observe system behavior under sudden memory or CPU spikes.
            // Probability: 2%
            if (_random.NextDouble() < 0.02) 
            {
                _logger.LogInformation("[STRESS ENJECTED] Simulating momentary memory pressure.");
                var stressBuffer = new byte[1024 * 1024 * 20]; // Temporary 20MB allocation
                _logger.LogDebug($"Allocated {stressBuffer.Length} bytes for stress test.");
            }

            try
            {
                // Proceed to the next middleware or controller if the request "survives" the chaos.
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[RESILIENCE ALERT] Real exception detected during chaos session: {ex.Message}");
                throw; // Rethrow to allow standard exception handling to be tested.
            }
        }
    }
}
